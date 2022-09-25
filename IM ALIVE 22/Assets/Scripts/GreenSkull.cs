using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSkull : MonoBehaviour
{
    public Vector2 direction = Vector2.down;
    [SerializeField] public float speed ;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
