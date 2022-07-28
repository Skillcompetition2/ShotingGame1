using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWeapon : MonoBehaviour
{
    MonsterStatus monsterStatus;
    PlayerStatus playerStatus;

    private void Awake()
    {
        monsterStatus = GetComponentInParent<MonsterStatus>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerStatus = other.GetComponent<PlayerStatus>();
            Attack();
        }
    }

    void Attack()
    {
        if(playerStatus != null)
        {
            playerStatus.HP -= monsterStatus.Attak_amount;
            Debug.Log("АјАн");

        }
    }
}
