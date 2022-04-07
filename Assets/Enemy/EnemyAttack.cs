using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    private EnemyData _enemyData;
    // Start is called before the first frame update
    public float enemyCooldown = 1;
    private int damage = 1;

    private bool playerInRange = false;
    private bool canAttack = true;
 

    public float attackRange = 0.5f;
    [SerializeField]private LayerMask enemyLayers;
    bool isDie;
    bool m_FacingRight = true;

    private void Awake(){
        animator = GetComponent<Animator>();
        _enemyData = GetComponent<EnemyData>();
    }
    private void Start(){
        
        playerInRange = false;
        damage = _enemyData._damage;
        StartCoroutine(StartCooldown());
    }
    private void Update()
    {
        isDie = transform.GetComponent<Enemy>().isDie;
        if (playerInRange && canAttack && !isDie)
        {
            animator.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position,attackRange,enemyLayers);
            foreach (Collider2D Player in hitEnemies)
            {   
                Player.GetComponent<Player>().TakeDamage(damage);
            }
            StartCoroutine(AttackCooldown());
        }
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

    void OnDrawGizmosSelected()
    {
        if (transform == null)
            return;

        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
}
