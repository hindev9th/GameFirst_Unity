using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelPause : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private GameObject Loading;
    [SerializeField]private GameObject Notification;
    [SerializeField]private TMP_Text editTextLoading;
    [SerializeField]private Player player;
    [SerializeField]private PlayerCombat playerCombat;
    public bool _loading = false;
    private void Awake(){
        animator = transform.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Loading.SetActive(false);
    }
    
    public void SettingGame(){
        animator.SetBool("Pause",true);
    }
    public void UnSettingGame(){
        animator.SetBool("Pause",false);
    }

    public void SavePlayer(){
        editTextLoading.text = "Saving...";
        StartCoroutine(TimeLoad(Loading));

        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayer(){
        
        editTextLoading.text = "Loading...";
        StartCoroutine(TimeLoad(Loading));
        _loading = true;  
    }
    public void Quit(){
        Application.Quit();
    }

    private void LoadData(){
        try{
            PlayerData data = SaveSystem.LoadPlayer();

            player.level = data.level;
            player.currentHealth = data.currentHealth;
            player._Physical = data._indexHp;
            player.currentXP = data.currentXP;
            player.MaxXP = data.maxXP;

            player._Strength = data._indexDamage;
            playerCombat.attackDamage = data.Damage;

            player._point = data._point;
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            player.transform.position = position;

            player.UpdateIndex_();
            

        }catch{
            Notification.SetActive(true);
        }
    }
    IEnumerator TimeLoad(GameObject obj){
        obj.SetActive(true);
        yield return new WaitForSeconds(2f);
        obj.SetActive(false);
        animator.SetBool("Pause",false);

        if (_loading)
        {
            LoadData();
            _loading = false;
        }
    }
    
}
