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

    // Update is called once per frame
    void Update()
    {
        Move();
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical"); 

        MoveTo(new Vector3(x,0,z));
    }

    void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
