using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{ 
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private Enemy enemy;
    [SerializeField]private LayerMask layerMaskEnemy;
    [SerializeField]private float vision = 2f;
    [SerializeField]private float Speed =1.5f;
    private float _currentSpeed;
    public Vector3 _enemyPosition;
    bool m_FacingRight = true;
    private void Awake(){
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    private void Start(){
        _enemyPosition = transform.position;
    }
    void Update(){

        Collider2D[] hithitEnemies = Physics2D.OverlapCircleAll(transform.position,vision,layerMaskEnemy);
        
        foreach(Collider2D player in hithitEnemies){
            if( Vector2.Distance((Vector2)transform.position ,player.transform.position) <= GetComponent<EnemyAttack>().attackRange || enemy.isDie){
                _currentSpeed =0;
            }else{
                _currentSpeed = Speed;
                transform.position = Vector2.MoveTowards(transform.position,player.transform.position,_currentSpeed * Time.deltaTime);
            }

            if (player.transform.position.x <= transform.position.x && m_FacingRight)
                Flip();
            if (player.transform.position.x >= transform.position.x && !m_FacingRight)
                Flip();     
        }


        if(hithitEnemies.Length == 0 && transform.position != _enemyPosition){
            _currentSpeed = Speed;
            transform.position = Vector2.MoveTowards(transform.position,_enemyPosition,_currentSpeed * Time.deltaTime);

            if (_enemyPosition.x <= transform.position.x && m_FacingRight)
                Flip();
            if (_enemyPosition.x >= transform.position.x && !m_FacingRight)
                Flip();     
        }else if(transform.position == _enemyPosition || enemy.isDie){
            _currentSpeed = 0;
        }
        
        animator.SetFloat("Speed",_currentSpeed);
    }

     private void Flip()
    {        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0,180,0);
    }

    void OnDrawGizmosSelected()
    {
        if (transform == null)
            return;

        Gizmos.DrawWireSphere(transform.position,vision);
    }
    
}
