using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator animator;
    public ButtonManager buttonManager;
    public readonly int hashPopup = Animator.StringToHash("isPopup");
    private void Start()
    {    
        animator = GetComponent<Animator>();
        animator.SetBool(hashPopup, false);
        buttonManager.buttonclick = (isOn) =>
        {
            if (isOn == true)
            {   
                Popup();
            }
            else
            {
                PopupClose();
            }
        };
    }
    public void Popup()
    {
        animator.SetBool(hashPopup, true);
    }
    public void PopupClose()
    {
        animator.SetBool(hashPopup, false);
    }
}
