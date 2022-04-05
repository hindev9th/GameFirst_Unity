using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private CircleCollider2D circleCollider2D;
    private HealthBar healthBar;
    //private int Level = 1;
    [SerializeField]private int XP = 50;
    [SerializeField]private int currentHeath;
    [SerializeField]private int maxHealth = 100;
    
    

    [SerializeField]private GameObject damageTextPrefab, enemyInstance;
    //public string textToDisplay;

    [SerializeField]private GameObject ItemRespawn;
    public Transform enemyOb;
    public bool isDie = false;

    private Vector3 EnemyPositionRepawn;

    private void Awake(){
        animator = transform.GetComponent<Animator>();
        circleCollider2D = transform.GetComponent<CircleCollider2D>();
        healthBar = transform.GetChild(0).GetChild(0).GetComponent<HealthBar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        EnemyPositionRepawn = transform.position;
    }

    public void TakeDamage(int damage)
    {
        currentHeath -= damage;
        healthBar.SetHealth(currentHeath);
        if (currentHeath > 0)
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
    
    void Update(){
        
    }
    void Die()
    {
        isDie = true;
        circleCollider2D.enabled = false;
        animator.SetBool("IsDie", true);
        
        GameObject.Find("Player").GetComponent<Player>().XP(XP);

        //Items Chest
        Instantiate(ItemRespawn,transform.position,Quaternion.identity);  

        StartCoroutine(timerespawn());
    }

    IEnumerator timerespawn(){

        yield return new WaitForSeconds(30f);
        animator.SetBool("IsDie", false);
        isDie = false;
        circleCollider2D.enabled = true;
        currentHeath = maxHealth;
        healthBar.SetHealth(currentHeath);
        animator.SetTrigger("FeedBack");
    }
    
}
