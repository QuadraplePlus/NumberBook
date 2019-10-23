using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellManager : MonoBehaviour
{
    public Text name;
    public Text age;
    public Text phoneNumber;
    public Text email;

    public void SetCellData(PersonInfo cellData)
    {
        this.name.text = cellData.Name;
        this.age.text = cellData.Age.ToString();
        this.phoneNumber.text = cellData.PhonNumber;
        this.email.text = cellData.Email;
    }
}
