using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movingSpeed;
    public Vector3 moveDirection;
    // Ensure that a character visually clears an obstacle;
    public Vector3 turnPoint;
    public float minDistToClear;

    void Start() {
        moveDirection = Vector3.down;
    }

    // Alaways try to move downwards to the played if possible.
    // No concave geometry therefore should never move up
    void FixedUpdate() {
        if (Physics2D.Raycast(transform.position, moveDirection, 0.5f)) {
            // Need to turn
            if (moveDirection == Vector3.down) {
                if (BoardManager.isRightHalf(transform.position.x)) {
                    // Move to left
                    moveDirection = Vector3.left;
                } else {
                    moveDirection = Vector3.right;
                }
                turnPoint = transform.position;
            } else {
                moveDirection = Vector3.down;
            }
        } else if (moveDirection != Vector3.down) {
            // Was clearing an obstacle
            if (Vector3.SqrMagnitude(turnPoint - transform.position) >= minDistToClear * minDistToClear) {
                moveDirection = Vector3.down;
            }
        }
        transform.position += moveDirection * movingSpeed * Time.deltaTime;
    }
}
