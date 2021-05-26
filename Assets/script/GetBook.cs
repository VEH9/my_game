using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject book;
    public MonoBehaviour Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update () {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (Vector2.Distance(Player.transform.position, book.transform.position) <= 1) 
            {
                // Открытие двери
            }
        }
    }
}
