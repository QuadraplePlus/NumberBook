using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONSLData;
using UnityEngine.UI;
using PersonInfoData;
public class ButtonCtrl : MonoBehaviour
{
    public Text nameText;
    public Text numberText;
    public Text EmailText;

    public void SaveFileButton()
    {
        JSONParser jSONParser = new JSONParser();
        jSONParser.Save(nameText, numberText, EmailText);
    }
}
