using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform groundDetection;
    private bool movingRight = true;
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            animator.SetBool("Attack", true);
            playerController.KillPlayer();
            //Destroy(gameObject);
        }

        else
        {
            animator.SetBool("Attack", false);
        }

// if(groundDetection.gameObject.CompareTag("Door")){

// Debug.Log("other.tag");

// }

    }

    // For Animation
    //Enemy Patroling

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

}
