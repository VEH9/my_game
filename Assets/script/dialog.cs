using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;


public class dialog : MonoBehaviour
{
    public MonoBehaviour Player;

    [SerializeField] TextMeshProUGUI text;

    [SerializeField] string[] lines;

    [SerializeField] private float TextSpeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Player.transform.position.x < -20)) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (text.text == lines[index])
            {
                IsNextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
            
        }
    }

    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (var e in lines[index].ToCharArray())
        {
            text.text += e;
            yield return new WaitForSeconds(TextSpeed);
        }
    }
    void IsNextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
