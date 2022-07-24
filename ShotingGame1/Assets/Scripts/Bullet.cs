using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool isFire;
    Vector3 direction;      //�Ѿ��� ���ư��� ����
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFire) //�߻�ó���� �� ��
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    public void Fire(Vector3 dir)
    {
        direction = dir;
        isFire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() == null)
            Destroy(gameObject);
    }
}
