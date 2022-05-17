using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerScript : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite openLocker;
    public Sprite closeLocker;
    public MoveBox box;
    public bool canOpen;

    private BoxCollider2D col;
    private bool hasBox;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        if (box == null)
        {
            hasBox = false;
        }
        else
        {
            hasBox = true;
        }
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closeLocker;
    }

    public void interact()
    {
        if (canOpen)
        {
            if (sr.sprite == openLocker)
            {
                transform.position += new Vector3(0.27f, 0, 0);
                col.offset -= new Vector2(0.27f, 0);
                sr.sprite = closeLocker;
            }
            else if (sr.sprite == closeLocker)
            {
                transform.position -= new Vector3(0.27f, 0, 0);
                col.offset += new Vector2(0.27f, 0);
                sr.sprite = openLocker;
                if (hasBox)
                {
                    box.transform.position = transform.position + new Vector3(.25f, 0, 0);
                    hasBox = false;
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
