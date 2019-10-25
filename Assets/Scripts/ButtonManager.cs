using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonManager : MonoBehaviour
{
    public GameManager manager;
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
    public void CloseSavePopup()
    {
        isOn = false;
        buttonclick(isOn);
        manager.SaveData();
        Debug.Log("저장완료");
    }
}
