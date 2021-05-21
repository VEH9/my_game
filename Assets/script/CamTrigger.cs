using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector2 vector;
    public Camera first;
    public Camera second;
    public MonoBehaviour Player;
    //public GameObject MainCamera;
   // public GameObject SecondCamera;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Player.transform.position = vector;
            second.depth = 2;
            first.depth = 1;
            //MainCamera.SetActive(!MainCamera.activeSelf);
        }

        //SecondCamera.SetActive(!SecondCamera.activeSelf);
    }
}
