using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private Player player;
    [SerializeField]private PlayerCombat playerCombat;
    [SerializeField]private GameObject Notification;

    public void PlayAgain(){
        
        player.level =1;
        player.maxHealth = 5*10;
        player.currentHealth = player.maxHealth;
        player.MaxXP = 500;
        player.currentXP = 0;
        player.Damage = playerCombat.attackDamage = (int)(5*1.5);

        player.XP(player.currentXP);

        player.transform.position = player.RespawnPoint;



        Time.timeScale = 1;
        
        animator.enabled= true;
        animator.SetBool("IsDie",false);  
        animator.SetTrigger("Attack");
        gameObject.SetActive(false);
        player._isDie = false;
    }

    public void Load(){
        try
        {
            PlayerData data = SaveSystem.LoadPlayer();
            player._isDie = data._isDie;
            player.level = data.level;
            player.currentHealth = data.currentHealth;
            player.maxHealth = data.maxHealth;
            player.currentXP = data.currentXP;
            player.MaxXP = data.maxXP;

            player.Damage = data.Damage;
            playerCombat.attackDamage = data.Damage;

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            player.transform.position = position;


            player.XP(data.currentXP);

            Time.timeScale = 1;
            
            animator.enabled= true;
            animator.SetBool("IsDie",false);  
            animator.SetTrigger("Attack");
                
            gameObject.SetActive(false);
        }
        catch (System.Exception)
        {
            Notification.SetActive(true);
        }
        
    }
    
    public void Quit(){
        Application.Quit();
    }
}
