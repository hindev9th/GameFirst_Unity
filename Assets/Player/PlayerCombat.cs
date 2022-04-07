using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    [SerializeField]private Transform attackPoint;
    [SerializeField]private LayerMask enemyLayers;

    private Player player;
    public float attackRange = 0.5f;
    public int attackDamage = 10;

    public float attackRate = 2f;
    public float nextAttackTime = .2f;
    private int damageRanDom;
    private bool canAttack;
    private float AttackTime;

    private void Awake(){
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }
    void Start(){
        canAttack = true;
        AttackTime = nextAttackTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if( player.currentHealth <=0){
            animator.SetBool("IsDie",true);  
            }else{
                Attack();
                AttackTime = nextAttackTime;
            }
            
        }
        
    }

    public void AttackButton(){
        
        if( player.currentHealth <=0){
            animator.SetBool("IsDie",true);  
        }else{
            Attack();
        }
    }
    void Attack()
    {
        if (canAttack)
        {
            //Play an attack animation
            animator.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
            damageRanDom = Random.Range(attackDamage, attackDamage + 5);
            foreach (Collider2D enemy in hitEnemies)
            {
                try
                {
                    enemy.GetComponent<Enemy>().TakeDamage(damageRanDom);
                }
                catch (System.Exception)
                {  
                    if(enemy.GetComponent<Chest_open>().currentHeath >0)
                        enemy.GetComponent<Chest_open>().TakeDamage(damageRanDom);
                }

            }
            StartCoroutine(AttackCooldown());
        }
    }

    

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        //DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(AttackTime);
        canAttack = true;
    }
}

