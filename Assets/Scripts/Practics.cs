using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PersonInfoData;
using System.IO;
public class Practics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PersonInfo personInfo = new PersonInfo("홍길동", "010-3333-4444", "asdq@das.com");

        string path = "Assets\\data.txt";
        // string path2 = $"{Application.persistentDataPath}\\data.txt";

        //StreamWriter streamWriter = new StreamWriter(path);
        //streamWriter.WriteLine("블라블라");
        //streamWriter.WriteLine("블라블라~");
        //streamWriter.Close();

        if(File.Exists(path))
        {
            StreamReader streamReader = new StreamReader(path);
            string jsonStr = streamReader.ReadToEnd();

            PersonInfoList personInfoList = JsonUtility.FromJson<PersonInfoList>(jsonStr);
            streamReader.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
