using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public Transform bulletPrefab;
    public float bulletSpeed = 3;
    public float frequency = 2;

    private float shootTimer = 0f;

    private void Start()
    {
        Shoot();
    }
    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= frequency)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position,
            Quaternion.Euler(bulletSpawnPoint.rotation.eulerAngles + new Vector3(0, 0, 90)));
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
    }
}
