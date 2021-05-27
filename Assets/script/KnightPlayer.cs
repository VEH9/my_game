using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class KnightPlayer  : MonoBehaviour
{
    [SerializeField]
    private int lives = 5;

    //public int Livesx 
    //{
    //    get { return lives; }
    //    set
    //    {
    //       if (value < 5) lives = value;
    //        livesBar.Refresh();
    //    }
    //}
    //private LivesBar livesBar;

    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15F;
    private bool isGrounded;

    //private Bullet bullet;

    private CharStateKnight State
    {
        get { return (CharStateKnight)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        //livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        //bullet = Resources.Load<Bullet>("Bullet");
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = CharStateKnight.Idle;

        //if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
        if (timeBtwAttack <= 0 && Input.GetMouseButtonDown(0)) Attack();
        else timeBtwAttack -= Time.deltaTime;
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void Run()
    {
        var direction = transform.right * Input.GetAxis("Horizontal");

        var position = transform.position;
        position = Vector3.MoveTowards(position, position + direction, speed * Time.deltaTime);
        transform.position = position;
        sprite.flipX = direction.x > 0.0F;

        if (isGrounded) State = CharStateKnight.Run;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private float timeBtwAttack;

    public float startTimeBtwAttack;

    public Transform attackPos;

    public float attackRange;

    public int damage;
    public LayerMask enemy;
    
    private void Attack()
    {
        State = CharStateKnight.Attack;
        Collider2D[] enimies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        foreach (var enimy in enimies)
        {
            enimy.GetComponent<Enemy>().TakeDamage(damage);
        }
        timeBtwAttack = startTimeBtwAttack;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("CanJump"))
            {
                isGrounded = true;
                break;
            }
            isGrounded = false;
            
        }
        //isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharStateKnight.Jump;
    }

    //    private void OnTriggerEnter2D(Collider2D collider)
    //    {

    //        Bullet bullet = collider.gameObject.GetComponent<Bullet>();
    //        if (bullet && bullet.Parent != gameObject)
    //        {
    //            ReceiveDamage();
    //        }
    //    }
    
}


public enum CharStateKnight
{
    Idle = 0,
    Run = 1,
    Jump = 2,
    Attack = 4,
    Fall = 3
}