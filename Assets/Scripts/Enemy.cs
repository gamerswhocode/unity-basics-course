using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fireCooldown = 2f;
    public GameObject bulletPrefab;
    private Transform bulletSpawnerLocation;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnerLocation = transform.Find("BulletSpawner");
        InvokeRepeating("Shoot", 1f, fireCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnerLocation.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
