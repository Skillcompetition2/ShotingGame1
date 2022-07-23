using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        //Camera�� ������� ��ġ
    public float smoothing = 5f;    //�ε巯�� ����

    Vector3 offset;     

    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 camPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, camPos, smoothing * Time.deltaTime);
    }
}
