using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    //variables for attacking
    public int attackDamage;
    public float attackRange = 0.5f;

    //player is not dead
    public bool dead = false;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Values relating to the speed of the character 
    public float MovementSpeed = 1;
    public float JumpForce = 1;


    private Rigidbody2D _rigidbody;


    private void Update()
    {
        // Controls left/right movement on the screen
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        //runs the movement animimation if player moves
        animator.SetFloat("Speed", Mathf.Abs(movement));

        // rotates the player left/right if they change directions
        if (!Mathf.Approximately(movement, 0))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;



        // If the spacebar is pressed, the sprite should jump
        if (Input.GetKey("space") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            jump();
        }

        if (Mathf.Abs(_rigidbody.velocity.y) == 0)
        //stops jump animation if player is on ground
        // (y velocity of 0 means player isn't falling)
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetMouseButtonDown(0))
            //if left mouse button is pressed
        {
            attack();
        }

    }


    void jump()
    {
        _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        //runs jump animation if player jumps
        animator.SetBool("IsJumping", true);

    }

    void attack()
    {
        //runs attack animation
        animator.SetTrigger("Attack");

        //detecs enemies in range of an attack
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }


    void OnDrawGizmosSelected()
    {
        //used to work out distance player can attack from
        if(attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}

