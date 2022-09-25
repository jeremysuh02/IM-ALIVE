using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {
    // Start is called before the first frame update
    Vector2 bounds;
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -bounds.x, bounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, -bounds.y, bounds.y);
        transform.position = viewPos;
    }
}
