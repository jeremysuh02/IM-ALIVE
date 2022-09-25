using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBulletMovement : MonoBehaviour {
    public Rigidbody2D bulletPrefab;
    public float force = 50f;
    public float angle;
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
        bulletPrefab = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        angle = arrowToPlayerAngle();
    }

    // Update is called once per frame
    void Update() {
        bulletPrefab.velocity = new Vector2(0, 1) * force;
    }

    float arrowToPlayerAngle() {
        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        return angle;
    }
}
