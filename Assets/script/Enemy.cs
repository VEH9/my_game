using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private float speed = 2.0F;
    
    [SerializeField]
    public Unit player;
    private bool dead;
    public int damage;
    public LayerMask enemy;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private CharStateWolf State
    {
        get { return (CharStateWolf)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !dead)
        {
            dead = true;
            State = CharStateWolf.Death;
           // Destroy(gameObject);
        }
        
       
        timeBtwAttack -= Time.deltaTime;
        
        float direction = player.transform.position.x - transform.position.x;
        if (Mathf.Abs(direction) < 5 && !dead)
        {
            Vector3 pos = transform.position;
            pos.x += Mathf.Sign(direction) * speed * Time.deltaTime;
            sprite.flipX = direction > 0.0F;
            State = CharStateWolf.Run;
            transform.position = pos;
            
        }

        //движение
    }

    /*    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && timeBtwAttack <= 0) 
        {
            Debug.Log("кусь");
            //player.ReceiveDamage();
            timeBtwAttack = startTimeBtwAttack;
        }
    }*/

    void Deadd()
    {
        Destroy(gameObject);
    }
    
    private Animator animator;
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health = -damage;
    }
}
public enum CharStateWolf
{
    Idle = 0,
    Run = 1,
    Death = 2,
    Default = 3
}
