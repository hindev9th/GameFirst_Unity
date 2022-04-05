using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class GetInfoPlayer : MonoBehaviour
{
    [SerializeField]private Player _player;
    [SerializeField]private TMP_Text Level,HP,XP,Damege;
    private TMP_Text txtLevel,txtHp,txtXP,txtDamge;
    // Start is called before the first frame update
    private void Awake() {
        _player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();
        Level = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        XP = this.gameObject.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>();
        HP = this.gameObject.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>();
        Damege = this.gameObject.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Level.text ="Level: " + _player.level.ToString();
        HP.text = "HP: " +_player.currentHealth+"/"+_player.maxHealth;
        XP.text = "XP: " +_player.currentXP+"/"+_player.MaxXP;
        Damege.text ="Damage: " + _player.Damage+"-"+(_player.Damage+4);
        
    }
}
