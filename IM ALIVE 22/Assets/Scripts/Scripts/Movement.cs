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
    private float prevSpeedX;
    private float prevSpeedY;
    public float dashDistance = 500f;
    bool isDashing = false;
    private const float DELTA_V = 0.005f;

    public Animator animator;
     
    // Start is called before the first frame update
    void Start(){
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // was a direction pressed this frame along with space?
         if (Input.GetKeyDown(KeyCode.LeftShift) && (horizontal != 0 || vertical != 0)) {
            isDashing = true;
        }

        // for the dash, a WIP
        //speedX = setSpeed(horizontal, speedX);
        //speedY = setSpeed(vertical, speedY);
       
       animator.SetFloat("Speed", horizontal);
        dashDistance = 0;
        if (isDashing) {
            dashDistance = 30f;
        }

        if (Input.GetButtonDown("Fire1")) {

        }

    }

    private void FixedUpdate() {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
        /*Vector2 movementVector = new Vector2(horizontal * (speedX + dashDistance), vertical * (speedY + dashDistance));
        body.velocity = movementVector;
        //speedX = prevSpeedX;
        //speedY = prevSpeedY;
        isDashing = false;
    } */

        // Still a WIP
        /*
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
        }*/

        // Manages increases and decreases in speedX or SpeedY (depending on the axis)
        /*private float setSpeed(float axis, float speedAxis) {
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
            return speedAxis; */
    } 
}

