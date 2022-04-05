using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Point : MonoBehaviour
{
    [SerializeField]private Player _player;
    [SerializeField]private TMP_Text Level;
    [SerializeField]private TMP_Text Physical,Strength,Pointt;
    // Start is called before the first frame update
    private void Awake() {
        _player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();
        Level = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();

        Physical = this.gameObject.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        Strength =this.gameObject.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        Pointt = this.gameObject.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>();

        Physical.text = _player._Physical.ToString();
        Strength.text = _player._Strength.ToString();
        Pointt.text = _player._point.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Level.text ="Level: " + _player.level.ToString();
        
    }

    public void Update_point(){
        Physical.text = _player._Physical.ToString();
        Strength.text = _player._Strength.ToString();
        Pointt.text = _player._point.ToString();
    }
    public void up_Physical(){
        if(Int32.Parse(Pointt.text) > 0){
            Pointt.text = (Int32.Parse(Pointt.text) - 1).ToString();
            Physical.text = (Int32.Parse(Physical.text) + 1).ToString();
        }
    }
    public void down_Physical(){
        if(Int32.Parse(Physical.text) > _player._Physical){
            Pointt.text = (Int32.Parse(Pointt.text) + 1).ToString();
            Physical.text = (Int32.Parse(Physical.text) - 1).ToString();
        }
    }
    public void up_Strength(){
        if(Int32.Parse(Pointt.text) > 0){
            Pointt.text = (Int32.Parse(Pointt.text) - 1).ToString();
            Strength.text = (Int32.Parse(Strength.text) + 1).ToString();
        }
    }
    public void down_Strength(){
        if(Int32.Parse(Strength.text) > _player._Strength){
            Pointt.text = (Int32.Parse(Pointt.text) + 1).ToString();
            Strength.text = (Int32.Parse(Strength.text) - 1).ToString();
        }
    }

    public void Update_point_Comfirm(){
        _player._Physical = Int32.Parse(Physical.text);
        _player._Strength = Int32.Parse(Strength.text);
        _player._point = Int32.Parse(Pointt.text);

        Physical.text = _player._Physical.ToString();
        Strength.text = _player._Strength.ToString();
        Pointt.text = _player._point.ToString();

        _player.UpdateIndex_();
    }
}
