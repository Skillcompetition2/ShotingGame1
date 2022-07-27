using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    public bool isMoveStart;                 //이동 중
    public bool isArrival;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.sqrMagnitude > 0f) //출발 하였는가 
        {
            isMoveStart = true;
            anim.SetTrigger("walk");
        }

        isArrival = isMoveStart && agent.remainingDistance <= 10f;  //목적지에 도착 하였는가
        



        agent.SetDestination(target.position);
    }
}
