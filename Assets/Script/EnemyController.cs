using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    //public float distance;
    //public Transform groundDetection;
    public bool movingRight;
    public Animator animator;
    private BoxCollider2D boxCollider2D;
    //public LayerMask platformlayerMask;


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            animator.SetBool("Attack", true);
            playerController.hurtPlayer();
            //Destroy(gameObject);
        }

        else
        {
            animator.SetBool("Attack", false);
            //animator.SetBool("Hurt", false);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            if (movingRight)
            {
                movingRight = false;
            }

            else
            {
                movingRight = true;
            }
        }
    }

    // For Animation
    //Enemy Patroling
    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 1f);
        return raycastHit2D.collider != null;
        // Physics2D.OverlapCircle(feetPos.position, checkRadious);
        // return 0;
    }

    private void Update()
    {
        if (movingRight)
        {
            transform.Translate(1 * Time.deltaTime * speed , 0,0);
            transform.localScale = new Vector2 (1,1);
        }

        else
        {
            transform.Translate(-1 * Time.deltaTime * speed , 0,0);
            transform.localScale = new Vector2 (-1,1);
        }
        // transform.Translate(Vector2.right * speed * Time.deltaTime);

        // RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, platformlayerMask);
        // if (groundInfo.collider == false)
        // {
        //     if (movingRight == true)
        //     {
        //         transform.eulerAngles = new Vector3(0, -180, 0);
        //         movingRight = false;
        //     }
        //     else
        //     {
        //         transform.eulerAngles = new Vector3(0, 0, 0);
        //         movingRight = true;
        //     }
        // }
    }

}
