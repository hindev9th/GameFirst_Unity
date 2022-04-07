using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private EnemyData _enemyData;
    private EnemyMovement _enemyMovement;
    private CircleCollider2D circleCollider2D;
    private HealthBar healthBar;
    
    [SerializeField]private GameObject damageTextPrefab, enemyInstance;
    //public string textToDisplay;

    [SerializeField]private GameObject ItemRespawn;
    public Transform enemyOb;
    public bool isDie = false;

    private Vector3 EnemyPositionRepawn;

    private void Awake(){
        animator = transform.GetComponent<Animator>();
        _enemyData = GetComponent<EnemyData>();
        _enemyMovement = GetComponent<EnemyMovement>();
        circleCollider2D = transform.GetComponent<CircleCollider2D>();
        healthBar = transform.GetChild(0).GetChild(0).GetComponent<HealthBar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(_enemyData._max_health);
        EnemyPositionRepawn = transform.position;
    }

    public void TakeDamage(int damage)
    {
        _enemyData._current_health -= damage;
        healthBar.SetHealth(_enemyData._current_health);
        if (_enemyData._current_health > 0)
        {
            GameObject DamageText = Instantiate(damageTextPrefab, enemyOb.position,Quaternion.identity);
            DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("-"+damage.ToString());

            animator.SetTrigger("FeedBack");
        }
        else
        {
            Die();
        }
    }
    void Die()
    {
        isDie = true;
        circleCollider2D.enabled = false;
        animator.SetBool("IsDie", true);
        
        GameObject.Find("Player").GetComponent<Player>().XP(_enemyData._xp);

        //Items Chest
        Instantiate(ItemRespawn,transform.position,Quaternion.identity);  

        StartCoroutine(timerespawn());
    }

    IEnumerator timerespawn(){

        yield return new WaitForSeconds(30f);
        animator.SetBool("IsDie", false);
        isDie = false;
        circleCollider2D.enabled = true;
        transform.position = _enemyMovement._enemyPosition;
        _enemyData._current_health = _enemyData._max_health;
        healthBar.SetHealth(_enemyData._current_health);
        animator.SetTrigger("FeedBack");
    }
    
}
