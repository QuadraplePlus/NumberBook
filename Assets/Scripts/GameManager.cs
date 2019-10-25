using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;    //파일 저장과 관련된 클래스가 있는 Using SYSTEM 네임스페이스

public class GameManager : MonoBehaviour
{
    [SerializeField] InputField nameField;
    [SerializeField] InputField phoneNumield;
    [SerializeField] InputField emailField;
    [SerializeField] TextAsset jsonFile;
    [SerializeField] RectTransform contentRectransform;
    [SerializeField] GameObject cellPerfab;

    const float height = 80f;
    string path = "Assets\\data.json";

    private void Start()
    {
        //LoatText();
    }
    public void SaveData()
    {
        Person pP = new Person(nameField.text, phoneNumield.text, emailField.text);

        List<Person> pList = new List<Person>();
        pList.Add(pP);
        PersonList personList = new PersonList();
        personList.personLitst = pList;

        string jsonStr = JsonUtility.ToJson(personList);        //Json유틸리티 함수를 통해 문자열들을 하나의 문자열로 묶음

        //경로    //오류가 뜰땐 특문 두개 넣기 ㅎ

        //모바일 기기, 컴퓨터 등 기계 운영체제에서 지정해주는 자동 경로설정
        //string path_2 = $"{Application.persistentDataPath}\\data.json";

        StreamWriter streamWriter = new StreamWriter(path);
        ////여러줄 쓰고 싶으면 WriteLine
        streamWriter.WriteLine(jsonStr);

        streamWriter.Close();   //스트림라이트라인 객체를 닫고 저장도 시켜서 파일을 완성시킴

        //LoatText();
    }
    void LoatText()
    {
        //해당 경로에 파일이 있는지 검출
        if (!File.Exists(path))
            return;
        else
        {
            StreamReader streamReader = new StreamReader(path);

            //파일을 읽어서 변수에 값을 반환
            string jsonStr = streamReader.ReadToEnd();

            //반환된 문자열을 객체도 되돌리기
            PersonList personList = JsonUtility.FromJson<PersonList>(jsonStr);

            //스트림 했으면 반드시 클로즈
            streamReader.Close();

            if (jsonFile != null)
            {
                List<Person> result = personList.personLitst;
                contentRectransform.sizeDelta = new Vector2(0, result.Count * height);


                for (int i = 0; i < result.Count; i++)
                {
                    Person values = result[i];

                    CellManager cell = Instantiate(cellPerfab, contentRectransform).GetComponent<CellManager>();
                   cell.SetCellData(values);
                }
            }
        }
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
//public void AddCell()
//{
//    if (jsonFile != null)
//    {
//        List<Person> result = ;
//        contentRectransform.sizeDelta = new Vector2(0, result.Count * height);


//        for (int i = 0; i < result.Count; i++)
//        {
//            Person values = result[i];

//            CellManager cell = Instantiate(cellPerfab, contentRectransform).GetComponent<CellManager>();
//            cell.SetCellData(values);
//        }
//    }
//}
