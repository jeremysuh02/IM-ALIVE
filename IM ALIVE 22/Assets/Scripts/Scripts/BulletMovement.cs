using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;
    public GameObject myself;

    public float force = 50f;
    // Start is called before the first frame update
    void Start()
    {
        bulletPrefab = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletPrefab.velocity = new Vector2(0, 1) * force;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ceiling")
        {
            Destroy(myself);
        }
    }
}
