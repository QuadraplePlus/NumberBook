using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using PersonInfoData;
using UnityEngine.UI;

namespace JSONSLData
{
    public class JasonManager : MonoBehaviour
    {
        [SerializeField] RectTransform contentRectransform;
        [SerializeField] GameObject cellPerfab;

        public Text nameText;
        public Text numberText;
        public Text EmailText;

        PersonInfoList personInfoList = new PersonInfoList();
        List<PersonInfo> people = new List<PersonInfo>();
        string jsonData;
        const float cellHeight = 80f;
        bool index = true;

        void CreateJsonFile(string createPath, string fileName, string jsonData)
        {
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);

            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
        }

        public void Save(Text name, Text number, Text email)
        {
            PersonInfo pp = new PersonInfo(name.text, number.text, email.text);
            people.Add(pp);

            personInfoList.personInfos = people;
        }

        public void Save2()
        {
            var jtc2 = LoadData<PersonInfoList>(Application.dataPath, "UserData");

            if (index)
            {
                for (int i = 0; i < jtc2.personInfos.Count; i++)
                {
                    people.Add(jtc2.personInfos[i]);
                }
            }
            personInfoList.personInfos = people;

            jsonData = ObjectToJson(personInfoList);

            CreateJsonFile(Application.dataPath, "UserData", jsonData);
        }

        public static T LoadData<T>(string loadPath, string fileName)
        {
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);

            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            fileStream.Close();

            string jsonData = Encoding.UTF8.GetString(data);

            return JsonUtility.FromJson<T>(jsonData);
        }

        public void Load()
        {
            var jtc2 = LoadData<PersonInfoList>(Application.dataPath, "UserData");

            contentRectransform.sizeDelta = new Vector2(0, jtc2.personInfos.Count * cellHeight);

            for (int i = 0; i < jtc2.personInfos.Count; i++)
            {
                Cell cell = Instantiate(cellPerfab, contentRectransform).GetComponent<Cell>();

                cell.SetCellData(jtc2.personInfos[i].Name, jtc2.personInfos[i].Number, jtc2.personInfos[i].Email);
            }

            for (int i = 0; i < jtc2.personInfos.Count; i++)
            {
                people.Add(jtc2.personInfos[i]);
            }

            index = false;
        }

        public string ObjectToJson(PersonInfoList obj)
        {
            return JsonUtility.ToJson(obj);
        }

        //문자열로 된 JSON데이터를 받아서 원하는 타입의 객체로 반환
        public T JsonToObject<T>(string jsonData)
        {
            return JsonUtility.FromJson<T>(jsonData);
        }

        public void SaveFileButton()
        {
            Save(nameText, numberText, EmailText);

            contentRectransform.sizeDelta = new Vector2(0, personInfoList.personInfos.Count * cellHeight);

            Cell cell = Instantiate(cellPerfab, contentRectransform).GetComponent<Cell>();

            for (int i = 0; i < personInfoList.personInfos.Count; i++)
            {
                cell.SetCellData(personInfoList.personInfos[i].Name, personInfoList.personInfos[i].Number, personInfoList.personInfos[i].Email);
            }

        }
        private void Start()
        {
            Load();
        }

        private void OnApplicationQuit()
        {
            Save2();
        }
    }
}