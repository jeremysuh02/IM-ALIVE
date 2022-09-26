using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSkull : MonoBehaviour
{
    public Vector2 direction = Vector2.down;
    [SerializeField] public float speed;
    public GameObject character;

    public int health = 18;
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

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