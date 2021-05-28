using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public KnightPlayer Player;
    
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private bool canRefr = false;
    private void Update()
    {
        if (canRefr)
            timeBtwAttack -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && timeBtwAttack <= 0)
        {
            Player.TakeDamage();
            timeBtwAttack = startTimeBtwAttack;
            canRefr = true;
        }
    }
}
