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

    private bool dead;

    //public GameObject qwe;
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
            State = CharStateWolf.Death;
           // Destroy(gameObject);
            dead = true;
        }
        //движение
    }

    void Deadd()
    {
        Destroy(gameObject);
    }
    
    private Animator animator;

    private void Awake()
    {
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
