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
        StartCoroutine(DeadAnim());
    }

    IEnumerator DeadAnim()
    {
        anim.SetTrigger("Dead");
        while (true)
        {

        }
    }
}
