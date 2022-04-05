using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Animator animator;
    public Player player;
    public PlayerCombat playerCombat;

    public GameObject Notification;
    //public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    public void PlayAgain(){
        player.level =1;
        player.currentHealth = 100;
        player.maxHealth = 100;
        player.currentXP = 0;
        player.MaxXP = 1000;
        player.Damage = playerCombat.attackDamage = 8;

        player.XP(player.currentXP);

        player.transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().RespawnPoint;



        Time.timeScale = 1;
        
        animator.enabled= true;
        animator.SetBool("IsDie",false);  
        animator.SetTrigger("Attack");
        gameObject.SetActive(false);
    }

    public void Load(){
        try
        {
            PlayerData data = SaveSystem.LoadPlayer();

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
