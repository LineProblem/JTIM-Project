using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamper : MonoBehaviour
{
    public SpriteRenderer blurSr;
    public SpriteRenderer sr;
    public Sprite empty;
    public Sprite full;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void interact()
    {
        if (!blurSr.enabled)
        {
            blurSr.enabled = true;
            sr.sprite = full;
        }
        else
        {
            if (sr.sprite == full)
            {
                sr.sprite = empty;
                blurSr.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
