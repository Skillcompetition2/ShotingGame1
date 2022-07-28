using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float fireDelay;
    [SerializeField] Transform firePos;
    float timer = 0;

    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        while (timer > fireDelay)
        {
            Fire();
            timer = 0;

        }
    }

    void Fire()
    {
        var bullet = Instantiate(BulletPrefab, firePos.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.Init(playerMovement.status.AttackSpeed, playerMovement.status.Power);
        bullet.Fire(playerMovement.lookDirection);

    }
}
