using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JSONManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //List<PersonInfo> personInfos = new List<PersonInfo>();
        Score s1 = new Score();
        s1.totalScore = 9999;
        s1.maxScore = 1000000;
        s1.stageScore = 555;

        PersonInfo p1 = new PersonInfo("홍길동", 28, "010-6574-7898", "die436wjiow@naer.com",s1);
        //PersonInfo p2 = new PersonInfo("박길동", 10, "010-6342-7898", "diew436jiow@naer.com");
        //PersonInfo p3 = new PersonInfo("최길동", 25, "010-1246-5124", "die346wjiow@na346er.com");
        //PersonInfo p4 = new PersonInfo("김길동", 27, "010-5122-7898", "diew463jiow@naer.com");
        //PersonInfo p5 = new PersonInfo("말길동", 44, "010-4123-7898", "di4444ewj123iow@naer.com");
        //PersonInfo p6 = new PersonInfo("소길동", 32, "010-4125-7898", "diewjiow@naer.com");
        //PersonInfo p7 = new PersonInfo("대길동", 24, "010-2312-7898", "di512ewjiow@naer.com");
        //PersonInfo p8 = new PersonInfo("중길동", 77, "010-5555-7898", "diewjiow@naer.com");
        //PersonInfo p9 = new PersonInfo("조길동", 45, "010-6664-7898", "diewjiow@naer.com");
        //PersonInfo p10 = new PersonInfo("고길동", 61, "010-3234-7898", "di643ewjiow@naer.com");

        //PersonInfo[] personInfos = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
        string p1Json = JsonUtility.ToJson(p1);

        Debug.Log(p1Json);
    }
    //파일 저장 역할을 하는 함수
    void SaveTofile(string jsonStr)
    {
        if (jsonStr.Length <= 0) return;

        FileStream fileStream = new FileStream(GetPath(Constant.FILE_NAME),FileMode.Create);
        //UTF8로 jsonStr 을 바이트 형식으로 인코딩
        byte[] data = Encoding.UTF8.GetBytes(jsonStr);
        fileStream.Write(data, 0, data.Length);

        fileStream.Close();
    } 

    string GetPath(string fileName)
    {
        string filePath = 
            string.Format("{0},{1}", Application.persistentDataPath, fileName);
        return filePath;
    }
}
