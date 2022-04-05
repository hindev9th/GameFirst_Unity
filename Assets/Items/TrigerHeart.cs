using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrigerHeart : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public int Health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartCooldown());
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.currentHealth += Health;
            if(player.currentHealth > player.maxHealth){
                player.currentHealth = player.maxHealth;
            }
            player.XP(0);
            
            GameObject DamageText = Instantiate(damageTextPrefab, GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().transform.position,Quaternion.identity);
            
            DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("+"+Health.ToString());
            DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().color = new Color32(0,255,0,1);
            
            Destroy(gameObject);
                
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {        
        
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
}
