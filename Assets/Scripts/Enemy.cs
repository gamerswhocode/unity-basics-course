using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fireCooldown = 2f;
    public GameObject bulletPrefab;
    private Transform bulletSpawnerLocation;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private const float moveDirectionTime = 1.5f;

    private float TotalMovementTime;
    
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnerLocation = transform.Find("BulletSpawner");
        InvokeRepeating("Shoot", 1f, fireCooldown);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingRight)
            transform.Translate(Vector3.right * movementSpeed);
        else
            transform.Translate(Vector3.left * movementSpeed);
        if (Time.time > TotalMovementTime)
        {
            TotalMovementTime = moveDirectionTime + Time.time;
            movingRight = !movingRight;
        }

    }

    IEnumerator MovementCoroutine()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(moveDirectionTime);
        }
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
