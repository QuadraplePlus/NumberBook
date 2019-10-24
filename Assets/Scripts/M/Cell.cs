using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI에 보이는 걸 조작
public class Cell : MonoBehaviour
{
    public Text name;
    public Text phoneNumber;
    public Text email;

    public void SetCellData(string name, string phoneNumber, string email)
    {
        this.name.text = name;
        this.phoneNumber.text = phoneNumber;
        this.email.text = email;
    }
}
