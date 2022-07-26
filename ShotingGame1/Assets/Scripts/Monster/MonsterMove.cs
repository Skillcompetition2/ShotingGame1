using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    public bool isMoveStart;                 //�̵� ��
    public bool isArrival;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.velocity.sqrMagnitude > 0f)    //��� �Ͽ��°�  
            isMoveStart = true;

        isArrival = isMoveStart && agent.remainingDistance <= 10f;  //�������� ���� �Ͽ��°�
        


        agent.SetDestination(target.position);
    }
}
