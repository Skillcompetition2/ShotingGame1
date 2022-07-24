using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStatus status;
   
    float moveSpeed //이동 속도
    {
        get
        {
            return status.Speed;
        }
    }

    [SerializeField] float jumpForce = 3.0f;
    float gravity = -9.81f;
    Vector3 moveDirection;                      //이동 방향
    Vector3 lookDirection;                      //바라보는 방향

    CharacterController characterController;

    private void Awake()
    {
        status = GetComponent<PlayerStatus>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //점프 체크
        if (Input.GetKeyDown(KeyCode.Space))
            JumpTo();


        if (characterController.isGrounded == false)        //바닥 충돌 체크 
            moveDirection.y += gravity * Time.deltaTime;    //y축 감소

        Move();
    } 

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical"); 

        moveDirection =  MoveTo(new Vector3 (x, 0, z));
        lookDirection = new Vector3 (x, 0, z);

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);   //이동

        transform.rotation = Quaternion.LookRotation(lookDirection);            //이동 방향으로 회전
    }

    Vector3 MoveTo(Vector3 direction)
    {
        return new Vector3(direction.x, moveDirection.y, direction.z);         //방향 벡터 구하기
    }

    void JumpTo()
    {
        if (characterController.isGrounded == true)
            moveDirection.y = jumpForce;
    }
}
