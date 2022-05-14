using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr.enabled = false;
    }

    public void interact()
    {
        print("interact");
        sr.enabled = true;
        videoPlayer.Play();
        StartCoroutine(wait());
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(10);
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
