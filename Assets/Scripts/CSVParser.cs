using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CSVParser : MonoBehaviour
{
    static public List<PersonInfo> LoadData(byte[] data)  
    {
        //TODO : 
        //매개변수로 CSV 파일에 대한 정보를 전달하면 SCV 파일을 읽어서 List<Dictionary<string, string>>형태로 변환       
        List<PersonInfo> resultList = new List<PersonInfo>();
        Stream stream = new MemoryStream(data);
        StreamReader reader = new StreamReader(stream);

        string lineValue;
        while ((lineValue = reader.ReadLine()) != null)
        {
            
            string[] values = lineValue.Split(',');

            //파일을 읽고 쓴다거나, 네이트워크 통신을 한다거나
            try
            {
            //    //실행해야하는 코드
            //    PersonInfo personInfo = new PersonInfo(values[0], int.Parse(values[1]), values[2], values[3]);

            //    resultList.Add(personInfo);
            }
            catch (FormatException e)
            {
                //예기치 못한 오류 발생 시 실행할 코드
                Debug.Log(e.Message);
            }
            //Dictionary<string, string> valueDic = new Dictionary<string, string>();

            //valueDic.Add("NAME", values[0]);
            //valueDic.Add("AGE", values[1]);
            //valueDic.Add("PHONENUMBER", values[2]);
            //valueDic.Add("EMAIL", values[3]);
        }
        reader.Close();

        return resultList;
    }
}
