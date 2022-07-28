using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    MonsterMove monsterMove;
    Animator anim;

    [SerializeField] bool isAttackCoroutine;

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
        else
        {
            if (isAttackCoroutine)
            {
                StopCoroutine(AttackCoroutine());
                isAttackCoroutine = false;
            }
            
        }
    }

    void Attack()
    {
        if (isAttackCoroutine)
            return;

        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {

        isAttackCoroutine = true;
        anim.SetTrigger("attack_01");
        Debug.Log("공격");

        while (true)
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("attack_01") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                Debug.Log("공격 끝");
                isAttackCoroutine=false;
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
