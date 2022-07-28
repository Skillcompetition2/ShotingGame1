using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    

    [SerializeField] float attack_amount; 
    public float Attak_amount
    {
        get { return attack_amount; }
        set { attack_amount = value; }
    }
    [SerializeField] float speed; 
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    [SerializeField] float hp;
    public float HP
    {
        get { return hp; }
        set {
            
            hp = value; 
            if(hp <= 0)
            {
                Dead();
            }
        
        }
    }

    void Dead()
    {
        Debug.Log("Á×À½");
    }
}
