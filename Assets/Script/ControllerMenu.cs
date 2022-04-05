using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ControllerMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject _menuPause;
    [SerializeField] private TMP_Text _txtHp ,_txtDamage;

    int i = 0;
    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Escape)){
        //     animator.SetBool("Pause",true);
        // }
    }
    public void up_(){
        i = Int32.Parse(_txtHp.text);
    }

    public void OpenMenu(){
        animator.SetBool("Open",true);
    }

    public void CloseMenu(){
        animator.SetBool("Open",false);
    }

    public void Pause(){
        _menuPause.SetActive(true);
        Time.timeScale = 0;
    }
}
