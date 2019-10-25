using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellManager : MonoBehaviour
{
    public Text name;
    public Text phoneNumber;
    public Text email;
    public void SetCellData(Person person)
    {
        name.text = person.name;
        phoneNumber.text = person.phoneNumber;
        email.text = person.email;
    }
}   