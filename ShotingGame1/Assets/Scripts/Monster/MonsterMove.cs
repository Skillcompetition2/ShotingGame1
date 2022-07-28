using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    MonsterStatus monsterStatus;

    [SerializeField] Transform target;
    NavMeshAgent agent;
    public bool isMoveStart;                 //�̵� ��
    public bool isArrival;

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
        if (agent.velocity.sqrMagnitude > 0f) //��� �Ͽ��°� 
        {
            isMoveStart = true;
            anim.SetTrigger("walk");
        }

        isArrival = isMoveStart && agent.remainingDistance <= 10f;  //�������� ���� �Ͽ��°�

        agent.SetDestination(target.position);
    }
}
