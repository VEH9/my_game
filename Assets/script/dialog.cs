using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;
using UnityEngine.SceneManagement;


public class dialog : MonoBehaviour
{
    private bool canSkip = false;
    public MonoBehaviour Player;

    [SerializeField] TextMeshProUGUI text;

    [SerializeField] string[] lines;

    [SerializeField] private float TextSpeed;

    private int index;
    // Start is called before the first frame update
    private void Awake()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {
        text.text = string.Empty;
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Player.transform.position.x < -20)) canSkip = true;
        
        if (Input.GetMouseButtonDown(0) && canSkip)
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
