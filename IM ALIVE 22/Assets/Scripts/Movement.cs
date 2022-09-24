using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour { 
    Rigidbody2D body;
    float horizontal;
    float vertical;

    [SerializeField] public float speed;
    public float SPEED_MAX = 10f;
    private float speedX = 1f;
    private float speedY = 1f;
    public float dashDistance = 15f;
    bool isDashing;
    float timeBetweenTaps = 0;
    float tapTimeX = 0;
    float tapTimeY = 0;
    private const float DELTA_V = 0.005f;
     
    // Start is called before the first frame update
    void Start(){
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        speedX = setSpeed(horizontal, speedX);
        speedY = setSpeed(vertical, speedY);

        // for the dash, still a WIP
        if (isTapped(horizontal)) {
            tapTimeX = Time.time;
        } 

        if (isTapped(vertical)) {
            tapTimeY = Time.time;
        }

        if (Input.GetButtonDown("Fire1"))
        {

        }
    }

    private void FixedUpdate() {
        body.velocity = new Vector2(horizontal * speedX, vertical * speedY);
    }

    // Still a WIP
    private void dash() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            isDashing = true;
            timeBetweenTaps = 0;
        }
        if (isDashing) {
            timeBetweenTaps += Time.deltaTime;
            if (timeBetweenTaps >= 0.1f) {
                isDashing = false;
            }
            body.velocity = new Vector2(horizontal * dashDistance, vertical * dashDistance);
        }
    }

    // Manages increases and decreases in speedX or SpeedY (depending on the axis)
    private float setSpeed(float axis, float speedAxis) {
        // Increasing / Decreasing Speed
        if (axis != 0) {
            speedAxis += speed * DELTA_V;
        } else if (speedAxis > 0) {
            speedAxis -= speed * DELTA_V * 100;
        }

        // Setting speed limits
        if (speedAxis < 1) {
            speedAxis = 1;
        } else if (speedAxis > SPEED_MAX) {
            speedAxis = SPEED_MAX;
        }
        return speedAxis;
    }

    private bool isTapped(float axis) {
        return axis != 0;
    }
}

