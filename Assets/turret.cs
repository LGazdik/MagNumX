using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float bulletForce = 200f;
    private float nextTimeToFire = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nextTimeToFire < Time.time)
        {
            Fire();
            nextTimeToFire = Time.time + 1 / fireRate;
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bulletForce, ForceMode2D.Impulse);


    }
}
