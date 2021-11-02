using System.Collections;
using System.Collections.Generic;
// using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    //public GameOverController gameOverController;
    public Animator animator;
    public float speed, jump;
    public float runSpeed = 4;
    public Rigidbody2D rb2d;
    //for fixjump
    // public Transform feetPos;
    private BoxCollider2D boxCollider2D;
    public LayerMask platformlayerMask;
    public float checkRadious;
    //public float restarDelay = 40;
    public GameObject[] hearts;
    public GameObject gameover;
    private int life;
    private bool dead;


    private void Awake() 
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>(); 
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    private void Update() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayMovemantAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);

        // Kill Player
        // if (dead == true)
        // {
        //     animator.SetBool("Enemy", true);
        //     StartCoroutine(gameOver());
        //     Debug.Log("Game Over");
        //     this.enabled = false;
        // }
    }

    public void killPlayer()
    {
        animator.SetBool("Enemy", true);
        //StartCoroutine(gameOver());
        Debug.Log("Game Over");
        this.enabled = false;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 1f, platformlayerMask);
        return raycastHit2D.collider != null;
        // Physics2D.OverlapCircle(feetPos.position, checkRadious);
        // return 0;
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
        if(isGrounded() == true && Input.GetKeyDown(KeyCode.Space))
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
        if(isGrounded () && Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if (isGrounded () && Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }

        //Fast Run
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("runKey", true);
            speed += runSpeed;
        }
            
        else if (Input.GetKeyUp(KeyCode.LeftShift))
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

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("downGround"))
            {
                killPlayer();
                //gameOver.SetActive
            }
        }

    // Key pickUp
    public void PickUpKey()
    {
        Debug.Log("Player pickup the key");
        scoreController.IncreaseScore(100);
    }

        // Kill Player
    public void hurtPlayer()
    {
        //animator.SetBool("Hurt",true);
        if (life >= 1)
        {
            //animator.SetBool("Hurt", true);
            life -= 1;
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                StartCoroutine(gameOver());
                killPlayer();
            }
        }
        // Debug.Log("Player Kill by Enemy");
        // //Destroy(gameObject);
        // //gameObject.name.Equals ("Enemy").GetComponent<BoxCollider2D>();
        // //gameObject.CompareTag("Enemy")
        // animator.SetBool("Enemy", true);
        // //SceneManager.LoadScene(4);
        // StartCoroutine(gameOver());
        // Debug.Log("Game Over");

        // //animator.SetBool("GameOver", true);
        // //ReloadLevel();
        // this.enabled = false;
    }

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(3f);
        //SceneManager.LoadScene(5);
        gameover.SetActive(true);
    }

    // Level Completed
    private void Start() 
    {
        life = hearts.Length;
    }
    
}
