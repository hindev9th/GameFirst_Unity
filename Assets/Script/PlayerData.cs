using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level,
        currentHealth,
        maxHealth,
        currentXP,
        maxXP,
        Damage; 
    
    public int _indexHp,
            _indexDamage,
            _point;
    public bool _isDie;
    public float[] position;

    public PlayerData(Player player){
        level = player.level;
        currentHealth = player.currentHealth;
        currentXP = player.currentXP;
        maxXP = player.MaxXP;
        _indexHp = player._Physical;
        _indexDamage = player._Strength;
        _point = player._point;
        _isDie = player._isDie;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
