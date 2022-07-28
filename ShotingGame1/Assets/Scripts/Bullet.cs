using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool isFire;
    Vector3 direction;      //총알이 날아가는 방향
    public float speed;
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
    }
    public void Init(float speed, float power)
    {
        this.speed = speed;
        this.power = power;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFire) //발사처리가 된 후
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
        if(other.gameObject.TryGetComponent(out MonsterStatus monster)){
            Debug.Log("닿았다");
            monster.HP -= power;
        }


        if (other.GetComponent<Bullet>() == null)
            Destroy(gameObject);

    }

}
