using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStatus status;
    Camera chracterCamera;
    Animator anim;
    bool isMove;

    float moveSpeed //�̵� �ӵ�
    {
        get
        {
            return status.Speed;
        }
    }

    [SerializeField] float jumpForce = 3.0f;
    float gravity = -9.81f;
    Vector3 moveDirection;                      //�̵� ����
    public Vector3 lookDirection;                      //���콺 ����

    CharacterController characterController;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        status = GetComponent<PlayerStatus>();
        characterController = GetComponent<CharacterController>();
        chracterCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

    }

    void Update()
    {
        //���� üũ
        if (Input.GetKeyDown(KeyCode.Space))
            JumpTo();

        anim.SetBool("isMove", isMove);

        if (characterController.isGrounded == false)        //�ٴ� �浹 üũ 
            moveDirection.y += gravity * Time.deltaTime;    //y�� ����

        Move();
    } 

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical"); 

        moveDirection =  MoveTo(new Vector3 (x, 0, z));

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);   //�̵�

        isMove = (x != 0 || z != 0);


        LookMouseCurser();

    }

    Vector3 MoveTo(Vector3 direction)
    {
        return new Vector3(direction.x, moveDirection.y, direction.z);         //���� ���� ���ϱ�
    }

    void JumpTo()
    {
        if (characterController.isGrounded == true)
        {
            anim.SetTrigger("isJump");
            moveDirection.y = jumpForce;

        }
    }

    void LookMouseCurser()
    {
        Ray ray = chracterCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            lookDirection = new Vector3(hit.point.x,transform.position.y,hit.point.z) - transform.position;
            transform.forward = lookDirection;
        }
    }
}
