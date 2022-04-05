using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public bool Death = false;
    public float Timer;
    public float Cooldown;
    public GameObject Enemy;
    public string EnemyName;
    GameObject LastEnemy;
    public Vector3 position;
   

    void Start(){
        Death = true;
    }
    // Update is called once per frame
    void Update () {
        
        if(Death == true) {
            //If my enemy is death, a timer will start.
            Timer += Time.deltaTime;  
        }
        
         //If the timer is bigger than cooldown.
        if(Timer >= Cooldown) {         
            RespownObjectEnemy();
        }
    }
    

    void RespownObjectEnemy(){
        //random point Respawn
        int RespawnPoint = Random.Range(1,5);
        
        Enemy.transform.position = transform.position;

        //It will create a new Enemy of the same class, at this position.
        Instantiate(Enemy);
        LastEnemy = GameObject.Find(Enemy.name + "(Clone)");
        LastEnemy.name = EnemyName;
        //My enemy won't be dead anymore.
        Death = false;
        //Timer will restart.
        Timer = 0;
        Destroy(gameObject);
    }
    
}
