using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_open : MonoBehaviour
{
    public Animator animator;
    
    public GameObject Items;

    public int maxHealth =5;
    public int currentHeath;

    void Start(){
        currentHeath = maxHealth;
    }

    public void TakeDamage(int damage){
        currentHeath -= damage;

        if(currentHeath <= 0){
            animator.SetTrigger("Open");
            //DropItem();
        }
    }
    public void Open(){
          
    }
    
    public void DropItem(){
        int rd = Random.Range(0,101);
        if(rd < 70)
            Instantiate(Items,transform.position,Quaternion.identity);
        
        Destroy(gameObject,.5f);
    }

    // void OnTriggerEnter2D(Collider2D other){
    //     if(other.gameObject.CompareTag("Player")){
    //         Open();
    //     }
    // }
}
