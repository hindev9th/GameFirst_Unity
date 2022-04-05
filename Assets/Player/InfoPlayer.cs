using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPlayer : MonoBehaviour
{
    public TMP_Text txtLevel,
        txtXp,
        txtHp,
        txtDamage;

    //coppy ben class Player
    public HealthBar XPBar;
    public TMP_Text LevelText,txtPtXp;

    public Player player;
    public PlayerCombat playerCombat;
    public int level =1,
        currentHealth,
        maxHealth = 100,
        currentXP=0,
        MaxXP =1000,
        Damage = 0;
    public int _indexHp = 5,
        _indexDamage = 5;
    public int xp1 = 950;
    void Start(){
        
    }
    public void UpdateIndex_(){
        maxHealth = _indexHp * 10;
        Damage = (int)(_indexDamage * 1.5);
    }
    public void LevelUp(int lv,int xp,int xpMax,int hpMax){

        XPBar.SetMaxXP(xpMax,xp);
        xp1 += xp;
        int damage = playerCombat.attackDamage;
        if(xp1 >= xpMax){
            xp1 -=xpMax;
            xpMax = player.MaxXP *=2;
            XPBar.SetMaxXP(xpMax,xp1);
            lv = player.level +=1;
            damage = playerCombat.attackDamage +=3;
            hpMax = player.maxHealth +=50;
            
            

        }
        XPBar.SetXP(xp1);
        //Tinh phan tram tong xp nhan dc
        float test = (float)xp1/(float)xpMax * 100;
        txtPtXp.text = test + " %";
        
        LevelText.text = "Level: "+ lv; 
        
        Info(lv,xp1,xpMax,hpMax,damage);
    }
    public void Info(int lv,int xp,int xpMax,int hp,int dm){
        txtLevel.text = "Lv: " + lv.ToString();
        txtXp.text = "XP: " + xp + " / " + xpMax;
        txtHp.text = "Hp: " + player.currentHealth + " / " + hp;
        txtDamage.text = "Damage: " + dm + " - " + (dm+4);
    }
}
