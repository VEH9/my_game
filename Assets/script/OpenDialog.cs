using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDialog : MonoBehaviour
{
    public Vector2 vector;
    public GameObject text;
    private bool complite = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || complite) return;
        complite = true;
        text.transform.position = vector;
        //MainCamera.SetActive(!MainCamera.activeSelf);

        //SecondCamera.SetActive(!SecondCamera.activeSelf);
    }
}