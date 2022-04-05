using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Rigidbody2D enemyRigidBody2D;
    public Animator animator;
    //public CharacterController2D controller;
    public GameObject Enemy;
    public int UnitsToMove = 2;
    public float EnemySpeed = 2;
    float EnemySpeedRun =0;
    Transform target;
    Vector2 enemyTran;
    bool trigger =false;
    bool isDie;
    bool m_FacingRight = true;

    
    void Start(){
        isDie = gameObject.GetComponent<Enemy>().isDie = false;
        StartCoroutine(AttackCooldown());
        trigger =false;
        if(!isDie){
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            enemyTran = transform.parent.transform.position;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            trigger = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("Player"))
        {
            trigger =false;
        }
    }

    void Update(){
        
        if(trigger && !isDie){
            if( Vector2.Distance((Vector2)transform.parent.transform.position ,target.position) <= GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAttack>().attackRange){
                EnemySpeedRun = 0;
                animator.SetFloat("Speed",EnemySpeedRun);
            }else{
                EnemySpeedRun = EnemySpeed;
                animator.SetFloat("Speed",EnemySpeedRun);
            }

            Enemy.transform.position = Vector2.MoveTowards(transform.parent.transform.position,target.position,EnemySpeedRun * Time.deltaTime);
            
                if(transform.position.x >= target.position.x && m_FacingRight)
                    Flip();
                
                if(transform.position.x <= target.position.x && !m_FacingRight)
                    Flip();

            
                
            
        }
        if(!trigger && !isDie){
            if((Vector2)transform.parent.transform.position == enemyTran){
                EnemySpeedRun = 0;
                animator.SetFloat("Speed",EnemySpeedRun);
            }else{
                EnemySpeedRun = EnemySpeed;
                animator.SetFloat("Speed",EnemySpeedRun);
                transform.position = Vector2.MoveTowards(transform.parent.transform.position,enemyTran,EnemySpeedRun * Time.deltaTime);
            
                if(transform.parent.transform.position.x >= enemyTran.x && m_FacingRight)
                    Flip();
                
                if(transform.parent.transform.position.x <= enemyTran.x && !m_FacingRight)
                    Flip();
            }    
        }
    }
    
    private void Flip()
    {        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.parent.transform.Rotate(0,180,0);
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0);
        trigger = false;
    }

    
}
