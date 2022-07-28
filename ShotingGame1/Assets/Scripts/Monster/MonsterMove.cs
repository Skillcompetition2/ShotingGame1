using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    MonsterStatus monsterStatus;

    [SerializeField] Transform target;
    NavMeshAgent agent;
    public bool isMoveStart;                 //이동 중
    public bool isArrival;
    public bool isDead;

    Animator anim;
    bool isDeadCoroutine;

    private void Awake()
    {
        monsterStatus = GetComponent<MonsterStatus>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        agent.speed = monsterStatus.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Dead();
            return;
        }

        if (!isMoveStart)
            anim.SetTrigger("idle");

        if (agent.velocity.sqrMagnitude > 0f) //출발 하였는가 
        {
            isMoveStart = true;
            anim.SetTrigger("walk");
        }

        isArrival = isMoveStart && agent.remainingDistance <= 10f;  //목적지에 도착 하였는가

        FindPlayer();
    }

    void FindPlayer()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, 50.0f);
        for (int i = 0; i < colls.Length; i++)
        {
            if(colls[i].CompareTag("Player"))
                agent.SetDestination(target.position);

        }

    }

    void Dead()
    {
        if (isDeadCoroutine)
            return;
        StartCoroutine(DeadAnim());
    }

    IEnumerator DeadAnim()
    {
        
        isDeadCoroutine = true;
        anim.SetTrigger("die");
        while (true)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                Destroy(gameObject, 2f);
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
