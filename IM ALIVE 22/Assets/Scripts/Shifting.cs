using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shifting : MonoBehaviour {
    // player shifting
    [SerializeField] public bool shifted;
    bool shiftPressed;

    // player position
    private float playerX;
    private float playerY;


    // boundary variables
    // left boundary on the left side of the screen
    private float posBoundLeft;
    // right boundary on the left side of the screen
    private float posBoundRight;
    // left boundary on the right side of the screen
    private float negBoundLeft;
    // right boundary on the right side of the screen
    private float negBoundRight;
    // Start is called before the first frame update
    void Start() {
        // all shift settings set to false by default
        shiftPressed = false;
        // instantiate the boundaries
        posBoundLeft = GameObject.FindWithTag("Pos_L").transform.position.x;
        posBoundRight = GameObject.FindWithTag("Pos_R").transform.position.x;
        negBoundLeft = GameObject.FindWithTag("Neg_L").transform.position.x;
        negBoundRight = GameObject.FindWithTag("Neg_R").transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.RightShift)) {
            shiftPressed = true;
        }

        // UPDATE POSITIONS EVERY FRAME
        playerX = transform.position.x;
        playerY = transform.position.y;

        // update the X coordinate when "shifting" to get to the other side of the screen
        if (shiftPressed && !shifted) {
            transform.position = new Vector2(playerX + Mathf.Abs(negBoundRight - negBoundLeft), playerY);
            playerX = transform.position.x;
            shifted = true;
        } else if (shiftPressed && shifted) {
            //transform.position = new Vector2(negBoundLeft + (playerX - boundLeftNearest_X), playerY);
            transform.position = new Vector2(playerX - Mathf.Abs(negBoundRight - negBoundLeft), playerY);
            playerX = transform.position.x;
            shifted = false;
        }
        shiftPressed = false;
        checkBounds();
    }

    private void checkBounds() {
        switch(shifted) {
            // case for when you're on the left side of the screen
            case false:
                if (playerX < posBoundLeft) {
                    transform.position = new Vector2(posBoundLeft + 0.5f, playerY);
                }
                if (playerX > posBoundRight) {
                    transform.position = new Vector2(posBoundRight - 0.5f, playerY);
                }
                break;
            // case for when you're on the right side of the screen
            case true:
                if (playerX < negBoundLeft) {
                    transform.position = new Vector2(negBoundLeft + 0.5f, playerY);
                }
                if (playerX > negBoundRight) {
                    transform.position = new Vector2(negBoundRight - 0.5f, playerY);
                }
                break;
        }
    }

    // Check which "SCREEN" the player is on
    private float getCurrentScreenBound(float boundA_X, float boundB_X, float player_X) {
        float screenDist = Mathf.Abs(negBoundRight - negBoundLeft);
        if (player_X > boundA_X && player_X < boundA_X + screenDist) {
            return boundA_X;
        } else return boundB_X;
    }
}
