using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public float enemyCooldown = 1;
    public int damage = 1;

    private bool playerInRange = false;
    private bool canAttack = true;
 

    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask enemyLayers;
     bool isDie;
    bool m_FacingRight = true;
    private void Start(){
        
        playerInRange = false;
        StartCoroutine(StartCooldown());
    }
    private void Update()
    {
        isDie = transform.GetComponent<Enemy>().isDie;
        if (playerInRange && canAttack && !isDie)
        {
            animator.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
            foreach (Collider2D Player in hitEnemies)
            {   
                if (Player.GetComponent<Transform>().position.x <= transform.position.x && m_FacingRight)
                {
                    Flip();
                }
                if (Player.GetComponent<Transform>().position.x >= transform.position.x && !m_FacingRight)
                {
                    Flip();
                }
                if(Player.GetComponent<Player>().currentHealth >0)
                    Player.GetComponent<Player>().TakeDamage(damage);
            }
            StartCoroutine(AttackCooldown());
        }
    }

    private void Flip()
    {        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0,180,0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"));
        {
            playerInRange = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"));
        {
            playerInRange = false;
        }
    }
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(enemyCooldown);
        canAttack = true;
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(0);
        playerInRange = false;
    }

    
}
