using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    MonsterMove monsterMove;
    Animator anim;

    private void Awake()
    {
        monsterMove = GetComponent<MonsterMove>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterMove.isArrival)
            Attack();
    }

    void Attack()
    {
        Debug.Log("АјАн");
    }
}
