using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float hp;
    public float HP
    {
        get { return hp; }
        set { hp = value; }
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

    [SerializeField] float attack_Amount;
    public float AttackAmount
    {
        get { return attack_Amount; }
        set { attack_Amount = value; }
    }

    void Dead()
    {
        Debug.Log("플레이어 죽음");
    }
}
