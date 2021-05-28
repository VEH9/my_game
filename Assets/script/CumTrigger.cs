using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CumTrigger : MonoBehaviour
{
    public Camera first;
    public Camera second;
    public MonoBehaviour Player;
    //public GameObject MainCamera;
    // public GameObject SecondCamera;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            var a = second.depth;
            second.depth = first.depth;
            first.depth = a;
            //MainCamera.SetActive(!MainCamera.activeSelf);
        }

        //SecondCamera.SetActive(!SecondCamera.activeSelf);
    }
}
