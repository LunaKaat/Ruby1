using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer ruby;
    [Header("Balance variables")]
    [SerializeField]
    private float moveSpeed = 1;

    public Rigidbody2D rigidBody;
    public GameObject healParticle;

    

    public int HP = 30;
    
    public int currentHP = 30;
    [SerializeField]
    private float jumpForce = 1;

    private float horizontal;
    private float vertical;
    private Vector3 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //movimiento
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
        
        animator.SetBool("RunSide", false);
        if (Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false;
            animator.SetBool("RunBack", false);
            animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
        
        // Right , RunSide
        if(Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true;
            animator.SetBool("RunBack", false);
            animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }

        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            if ((currentHP - collision.GetComponent<Hazard>().damageAmount) < 0)
                currentHP = 0;
            else
                currentHP -= collision.GetComponent<Hazard>().damageAmount;
            
            animator.SetTrigger("DamageSide");
            currentHP -= collision.GetComponent<Hazard>().damageAmount;
            animator.SetTrigger("DamageSide");
        }

        if(collision.CompareTag("Heal"))
        {
            currentHP += collision.GetComponent<Heal>().healAmount;

            
            
            //activar heal particles

            if ((currentHP + collision.GetComponent<Heal>().healAmount) > HP)
                currentHP = HP;
            else
                currentHP += collision.GetComponent<Heal>().healAmount;
        }

        if(collision.CompareTag("Enemy"))
        {
            if ((currentHP - collision.GetComponent<Enemy>().damageAmount) < 0)
                currentHP = 0;
            else
                currentHP -= collision.GetComponent<Enemy>().damageAmount;
            
                


            animator.SetTrigger("DamageSide");
            currentHP -= collision.GetComponent<Enemy>().damageAmount;
            animator.SetTrigger("DamageSide");

        }
    }
}
