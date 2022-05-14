using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroll : MonoBehaviour
{
    public int waitTime;
    private bool scrolling = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
        scrolling = true;

    }


    private IEnumerator wait2()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Start");
    }


    // Update is called once per frame
    void Update()
    {
        if (scrolling)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
        if (transform.position.y > 30)
        {
            scrolling = false;
            StartCoroutine(wait2());
        }
    }
}
