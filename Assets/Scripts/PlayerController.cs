using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bulletPrefab;
    private Transform bulletSpawnerLocation;


    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bulletSpawnerLocation = transform.Find("BulletSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        if (horizontalMovement != 0)
        {
            float moveX = horizontalMovement * Time.deltaTime * moveSpeed;
            transform.Translate(moveX, 0, 0);
        }

        float verticalMovement = Input.GetAxis("Vertical");
        if (verticalMovement != 0)
        {
            float moveY = verticalMovement * Time.deltaTime * moveSpeed;
            transform.Translate(0, moveY, 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("rotate");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnerLocation.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") || collision.CompareTag("bullet enemy"))
        {
            Destroy(gameObject);
        }
    }
}
