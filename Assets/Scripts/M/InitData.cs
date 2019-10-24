using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PersonInfoData
{
    //데이터 저장 클래스
    [System.Serializable]
    public class PersonInfo
    {
        public string Name;
        public string Number;
        public string Email;

        public PersonInfo(string name, string number, string email)
        {
            this.Name = name;
            this.Number = number;
            this.Email = email;
        }
    }

    public class PersonInfoList
    {
        public List<PersonInfo> personInfos;
    }

    public class InitData : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }
    }
}
