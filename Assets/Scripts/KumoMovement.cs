using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumoMovement : MonoBehaviour
{   
    public float speed;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;
    

    public float jumpForce;
    private bool isJumping;
    
    private bool jumpAnim;
    private bool coverAnim;
    public Animator JumpAnimator;
    public Animator animator;
    public Animator coverAnimator;

    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public CapsuleCollider2D kumoCollider;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    public static KumoMovement instance;

    private void Awake()
    {
      
      if(instance != null)
      {
        Debug.LogWarning("Il y'a plus d'une instance de KumoMovement dans la scène");
        return;
      }

      instance = this;
    }

    void Update()
    {
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);
      
      horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

     if(Input.GetButtonDown("Jump") && isGrounded)
     {
        isJumping = true;       
     }

     if(isGrounded == true)
     {
        JumpAnimator.SetBool("jumpAnim", false);
     }else if(isGrounded == false)
     {
        JumpAnimator.SetBool("jumpAnim", true);
     }

     if(Input.GetKey(KeyCode.S))
     {
        coverAnimator.SetBool("coverAnim", true);
        speed = 0f;
     }else
     {
        coverAnimator.SetBool("coverAnim", false);
        speed = speed;
     }

      Flip(rb.velocity.x);
        
      float KumoVelocity = Mathf.Abs(rb.velocity.x);
      animator.SetFloat("speed", KumoVelocity);
    }
   
    void FixedUpdate()
    {
       MoveKumo(horizontalMovement);
    }

    void MoveKumo(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }    

    void Flip(float _velocity)
    {
      if(_velocity > 0.1f)
      {
          sr.flipX = false;
      }else if(_velocity < -0.1f)
      {
          sr.flipX = true;
      }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
