using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    float hp;
    public float HP
    {
        get { return hp; }
        set { hp = value; }
    }
    float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    float power;
    public float Power
    {
        get { return power; }
        set { power = value; }
    }

    float attackSpeed;
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
