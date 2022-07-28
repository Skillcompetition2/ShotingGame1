using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float hp;
    public float HP
    {
        get { return hp; }
        set { 
            hp = value; 
            if(hp >= 0)
            {
                Dead();
            }
        
        }
    }
    [SerializeField] float speed = 5.0f;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    [SerializeField] float power;
    public float Power
    {
        get { return power; }
        set { power = value; }
    }

    [SerializeField] float attackSpeed;
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }

    void Dead()
    {
        Debug.Log("플레이어 죽음");
    }
}
