using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCircle : MonoBehaviour
{
    [SerializeField] float Speed = 3f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    public int health = 3;
    public GameObject character;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameObject.Find("Player 1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }
    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * Speed;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            Destroy(collision.gameObject);
        }
        if (health < 1)
        {
            Destroy(character);
        }
    }
}

