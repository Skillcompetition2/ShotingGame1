using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;    //�̵� �ӵ�
    Vector3 moveDirection;                      //�̵� ����

    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    } 

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical"); 

        moveDirection = new Vector3(x,0,z);

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}
