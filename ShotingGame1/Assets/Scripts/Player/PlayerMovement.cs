using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;    //이동 속도
    [SerializeField] float jumpForce = 3.0f;
    float gravity = -9.81f;
    Vector3 moveDirection;                      //이동 방향
    Vector3 lookDirection;                      //바라보는 방향

    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (characterController.isGrounded == false)        //바닥 충돌 체크 
            moveDirection.y += gravity * Time.deltaTime;    //y축 감소

        //점프 체크
        if (Input.GetKeyDown(KeyCode.Space))
            JumpTo();

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
