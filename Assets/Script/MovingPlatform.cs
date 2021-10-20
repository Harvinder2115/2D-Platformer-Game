using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float dirX, moveSpeed = 2f;
    bool moveRight = true;

    private void Update() 
    {
        if (transform.position.x > 1f * Mathf.Abs(1))
            moveRight = false;
        else if (transform.position.x < -1f * Mathf.Abs(1))
                moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
}
