using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBulletMovement : MonoBehaviour {
    public Rigidbody2D bulletPrefab;
    public float force = 8f;

    // Start is called before the first frame update
    void Start() {
        bulletPrefab = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        bulletPrefab.velocity = new Vector2(0, -1) * force;
    }
}
