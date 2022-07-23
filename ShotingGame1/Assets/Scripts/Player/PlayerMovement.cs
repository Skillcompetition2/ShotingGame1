using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;    //�̵� �ӵ�
    [SerializeField] float jumpForce = 3.0f;
    float gravity = -9.81f;
    Vector3 moveDirection;                      //�̵� ����
    Vector3 lookDirection;                      //�ٶ󺸴� ����

    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (characterController.isGrounded == false)        //�ٴ� �浹 üũ 
            moveDirection.y += gravity * Time.deltaTime;    //y�� ����

        //���� üũ
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

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);   //�̵�

        transform.rotation = Quaternion.LookRotation(lookDirection);            //�̵� �������� ȸ��
    }

    Vector3 MoveTo(Vector3 direction)
    {
        return new Vector3(direction.x, moveDirection.y, direction.z);         //���� ���� ���ϱ�

    }

    void JumpTo()
    {
        if (characterController.isGrounded == true)
            moveDirection.y = jumpForce;
    }
}
