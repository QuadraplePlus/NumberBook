using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSVManager : MonoBehaviour
{
    [SerializeField] TextAsset csvFile;
    [SerializeField] RectTransform contentRectTransform;
    [SerializeField] GameObject cellPrefab;
    
    const float cellHeight = 60f;

    private void Start()
    {
        if (csvFile != null)
        {
            List<PersonInfo> result = CSVParser.LoadData(csvFile.bytes);
            contentRectTransform.sizeDelta = new Vector2(0, result.Count * cellHeight);

            
            for(int i = 0; i <result.Count; i++ )
            {
                PersonInfo values = result[i];
                
                CellManager cell = Instantiate(cellPrefab, contentRectTransform).GetComponent<CellManager>();
                cell.SetCellData(values);
            }
        }
    }
}