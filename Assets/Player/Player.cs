using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private HealthBar healthBar,XPBar;
    [SerializeField]private TMP_Text txtLvBar;
    [SerializeField]private TMP_Text txtLevel,
        txtXp,
        txtHp,
        txtDamage;
    [SerializeField]private PlayerCombat playerCombat;
    public int level =1,
        currentHealth,
        maxHealth = 100,
        currentXP=0,
        MaxXP =500,
        Damage = 0;
    public int _Physical = 5,
        _Strength = 5,
        _point = 0;

    [SerializeField]private GameObject damageTextPrefab;

    [SerializeField]private Transform CeilingPoint;

    [SerializeField]private GameObject gameOver;
    public Vector3 RespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = transform.position;

        UpdateIndex_();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        XP(currentXP);
        
    }
    
    // Update is called once per frame
    void Update()
    {

        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth > 0){
            GameObject DamageText = Instantiate(damageTextPrefab, CeilingPoint.position,Quaternion.identity);
            DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("-"+damage.ToString());
            txtHp.text = currentHealth + " / " + maxHealth ;
            animator.SetTrigger("FeedBack");
        }
        

        //Is Die
        if(currentHealth <=0){
            //Die();
            animator.SetBool("IsDie",true);  
        }
    }
    // private void Die(){
    //     animator.SetBool("IsDie",true);   
    // }
    public void pauseAnimatorDie(){
        animator.enabled = false;
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
        
    }
    
    public void UpdateIndex_(){
        maxHealth = _Physical * 10;
        Damage = (int)(_Strength * 1.5);
        playerCombat.attackDamage = Damage;   
         
        Info(level,currentXP,MaxXP,maxHealth,Damage);
    }

    public void XP(int XP){
        currentXP += XP;
        Damage = playerCombat.attackDamage;

        if(currentXP >= MaxXP){
            LevelUp(); 
        } 
        Info(level,currentXP,MaxXP,maxHealth,Damage);
    }
    
    public void LevelUp(){        
        currentXP -=MaxXP;
        MaxXP *=2;
        level++;
        _point += 5;

        GameObject DamageText = Instantiate(damageTextPrefab, CeilingPoint.position,Quaternion.identity);
        DamageText.transform.GetChild(0).GetComponent<TMP_Text>().text = "Level up";
        
    }
    public void Info(int lv,int currentXp,int xpMax,int MaxHp,int dm){
        healthBar.SetMaxHealth(maxHealth); 
        healthBar.SetHealth(currentHealth);
        XPBar.SetMaxXP(currentXP,MaxXP);
        XPBar.SetXP(currentXP);
        txtLvBar.text = level.ToString(); 

        txtLevel.text = "Lv: " + lv.ToString();
        txtXp.text = currentXp + " / " + xpMax;
        txtHp.text = currentHealth + " / " + MaxHp;
        txtDamage.text = "Damage: " + dm + " - " + (dm+4);
    }
}
