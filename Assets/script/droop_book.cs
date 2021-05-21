using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droop_book : MonoBehaviour
{
    public Vector2 vector;
    public GameObject book;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            book.transform.position = vector;
            //MainCamera.SetActive(!MainCamera.activeSelf);
        }

        //SecondCamera.SetActive(!SecondCamera.activeSelf);
    }
}