//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;
//using System;
//using System.Text;
//using PersonInfoData;
//using UnityEngine.UI;

//namespace JSONSLData
//{
//    public class JSONManager : MonoBehaviour
//    {
//        //public Action<bool> buttonclick;
//        //public static bool isOn;

//        [SerializeField] TextAsset JsonFile;
//        [SerializeField] RectTransform contentRectransform;
//        [SerializeField] GameObject cellPerfab;

//        public Text nameText;
//        public Text numberText;
//        public Text EmailText;

//        const float Heigth = 100f;

//        private void Awake()
//        {
//            Load();
//        }

//        private void start()
//        {
//            isOn = false;
//        }
//        void CreateJsonFile(string createPath, string fileName, string jsonData)
//        {
//            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);

//            byte[] data = Encoding.UTF8.GetBytes(jsonData);
//            fileStream.Write(data, 0, data.Length);
//            fileStream.Close();
//        }
//        public void Save(Text name, Text number, Text email)
//        {
//            PersonInfoList personInfoList = new PersonInfoList();

//            PersonInfo pp = new PersonInfo(name.text, number.text, email.text);

//            List<PersonInfo> people = new List<PersonInfo>();
//            people.Add(pp);

//            personInfoList.personInfos = people;

//            string jsonData = ObjectToJson(personInfoList); //제이슨 파일로 쓴다.

//            CreateJsonFile(Application.dataPath, "UserData", jsonData);

//        }
//        public static T LoadData<T>(string loadPath, string fileName)
//        {
//            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);

//            byte[] data = new byte[fileStream.Length];
//            fileStream.Read(data, 0, data.Length);
//            fileStream.Close();

//            string jsonData = Encoding.UTF8.GetString(data);

//            return JsonUtility.FromJson<T>(jsonData);
//        }
//        public void Load()
//        {
//            var jtc2 = LoadData<PersonInfoList>(Application.dataPath, "UserData");
//            contentRectransform.sizeDelta = new Vector2(0, jtc2.personInfos.Count * Heigth);
//            for (int i = 0; i < jtc2.personInfos.Count; i++)
//            {
                
//                CellManager cell = Instantiate(cellPerfab, contentRectransform).GetComponent<CellManager>();

//                cell.SetCellData(jtc2.personInfos[i].Name, jtc2.personInfos[i].Number, jtc2.personInfos[i].Email);
//            }
//        }
//        //오브젝트를 문자열로 된 JSON 데이터로 변환하여 반환
//        public string ObjectToJson(PersonInfoList obj)
//        {
//            return JsonUtility.ToJson(obj);
//        }

//        //문자열로 된 JSON데이터를 받아서 원하는 타입의 객체로 반환
//        public T JsonToObject<T>(string jsonData)
//        {
//            return JsonUtility.FromJson<T>(jsonData);
//        }
//        public void SaveFileButton()
//        {
//            Save(nameText, numberText, EmailText);

//            Load();
//            CloseSavePopup();
//        }
//        public void OpnePopup()
//        {
//            isOn = true;
//            buttonclick(isOn);
//        }
//        public void ClosePopup()
//        {
//            isOn = false;
//            buttonclick(isOn);
//        }
//        public void CloseSavePopup()
//        {
//            isOn = false;
//            buttonclick(isOn);
//        }
//    }

//}
