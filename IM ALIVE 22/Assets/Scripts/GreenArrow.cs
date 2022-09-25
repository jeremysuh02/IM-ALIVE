using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrow : MonoBehaviour {

    [SerializeField] float speed = 2f;
    Rigidbody2D rb;
    Vector2 moveDirection;
    int health = 2;
    private float enemyX;
    GameObject player;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {
        enemyX = transform.position.x;
        player = GameObject.FindWithTag("Player");
        moveDirection = new Vector2(0, -1 * speed);
    }

    // Update is called once per frame
    void Update() {
        float shootAngle = arrowToPlayerAngle();
        shootAtAngle(shootAngle);
    }

    void FixedUpdate() {
        rb.velocity = moveDirection;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            health--;
            Destroy(collision.gameObject);
        }
        if (health < 1) {
            Destroy(character);
        }
    }

    float arrowToPlayerAngle() {
        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        return angle;
    }

    void shootAtAngle(float angle) {
        //rb.rotation = angle;
        //moveDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        //rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
    }
}
