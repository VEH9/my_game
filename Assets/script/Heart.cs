using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        KnightPlayer knight = collider.GetComponent<KnightPlayer>();

        if (knight)
        {
            knight.Lives++;
            Destroy(gameObject);
        }
    }
}
