using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//제이슨 형식의 파일은 문자열의 리스트를 한번에 담을수가 없으므로, 정보를 담고있는 클래스의 리스트를 아예 만들어야한다
public class PersonList
{
    public List<Person> personLitst;
}
//문자열을 파일 로 저장을 하려면 직렬화는 필수 
[System.Serializable]
public class Person : MonoBehaviour
{
    //맴버변수
    public string name;
    public string phoneNumber;
    public string email;
     
    //맴버변수 생성자
    public Person(string name, string phoneNumber, string email)//전달 받고 싶은값)
    {
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.email = email;
    }
}   
