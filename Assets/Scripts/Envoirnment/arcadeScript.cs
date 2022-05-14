using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcadeScript : MonoBehaviour
{
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr.enabled = false;
    }

    public void interact()
    {
        sr.enabled = true;
        StartCoroutine(wait());
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
