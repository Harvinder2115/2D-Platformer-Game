using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public Animator animator;
    public float speed, jump;
    public float runSpeed = 4;
    public Rigidbody2D rb2d;
    //for fixjump
    public Transform feetPos;
    private bool isGrounded;
    public float checkRadious;
    public float restarDelay = 480;


    // private void Awake() 
    // {
    //     rb2d = gameObject.GetComponent<Rigidbody2D>(); 
    // }

    private void Update() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayMovemantAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadious);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {   
        //Move character hirizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Move character vertically (Jump)
        // if(vertical > 0)
        // {
        //     rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        // }

        // fix jump
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jump;
        }
    }

    private void PlayMovemantAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed",Mathf.Abs (horizontal));
        Vector3 scale = transform.localScale;
        if(horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs (scale.x);
        }
        else if(horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }        
        transform.localScale = scale;

        // Jump 
        if(vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        // Crouch 
        if(isGrounded == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if (isGrounded == true && Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }

        //Fast Run
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("runKey", true);
            speed += runSpeed;
        }
            
        else if (isGrounded == true && Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("runKey", false);
            speed -= runSpeed;
        }

        // Player Hurt
        // if()

    }

    private void OnCollisionEnter2D(Collision2D MP) 
    {
        if (MP.gameObject.name.Equals ("MovingPlatform"))
            this.transform.parent = MP.transform;   
    }

        private void OnCollisionExit2D(Collision2D MP) 
    {
        if (MP.gameObject.name.Equals ("MovingPlatform"))
            this.transform.parent = null;   
    }

    // Key pickUp
    public void PickUpKey()
    {
        Debug.Log("Player pickup the key");
        scoreController.IncreaseScore(100);
    }

        // Kill Player
    public void KillPlayer()
    {
        Debug.Log("Player Kill by Enemy");
        //Destroy(gameObject);
        //gameObject.name.Equals ("Enemy").GetComponent<BoxCollider2D>();
        //gameObject.CompareTag("Enemy")
        animator.SetBool("Enemy", true);
        //SceneManager.LoadScene(1);
        StartCoroutine(LoadLevelAfterDelay(restarDelay));
        Debug.Log("Game Over");

        //animator.SetBool("GameOver", true);
        //ReloadLevel();
        this.enabled = false;
    }

    IEnumerator LoadLevelAfterDelay(float restarDelay)
    {
        yield return new WaitForSeconds(restarDelay);
        SceneManager.LoadScene(2);
    }

    // Level Completed
    
}
