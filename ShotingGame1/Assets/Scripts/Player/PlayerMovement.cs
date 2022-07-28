using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStatus status;
    Camera chracterCamera;
    Animator anim;
    bool isMove;

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
    public Vector3 lookDirection;                      //마우스 방향

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
        //점프 체크
        if (Input.GetKeyDown(KeyCode.Space))
            JumpTo();

        anim.SetBool("isMove", isMove);

        if (characterController.isGrounded == false)        //바닥 충돌 체크 
            moveDirection.y += gravity * Time.deltaTime;    //y축 감소

        Move();
    } 

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical"); 

        moveDirection =  MoveTo(new Vector3 (x, 0, z));

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);   //이동

        isMove = (x != 0 || z != 0);


        LookMouseCurser();

    }

    Vector3 MoveTo(Vector3 direction)
    {
        return new Vector3(direction.x, moveDirection.y, direction.z);         //방향 벡터 구하기
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
