using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{
    public Action<bool> buttonclick;
    public static bool isOn;
    private void Start()
    {
        isOn = false;
    }
    public void OpnePopup()
    {
        isOn = true;
        buttonclick(isOn);
    }
    public void ClosePopup()
    {
        isOn = false;
        buttonclick(isOn);
    }
    public void Save()
    {

    }
}
