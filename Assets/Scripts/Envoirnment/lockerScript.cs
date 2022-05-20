using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lockerScript : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite openLocker;
    public Sprite closeLocker;
    public GameObject box;
    public bool canOpen;
    private PlayerControl player;
    public TextMeshProUGUI text;

    private BoxCollider2D col;
    private bool hasBox;
    public bool locked;

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

        player = FindObjectOfType<PlayerControl>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closeLocker;
        if (locked)
        {
            text.text = "";
        }
    }

    public void interact()
    {
        if (!locked)
        {
            if (canOpen)
            {
                if (sr.sprite == openLocker)
                {
                    transform.position += new Vector3(0.27f, 0, 0);
                    col.offset -= new Vector2(0.27f, 0);
                    sr.sprite = closeLocker;
                    sr.sortingOrder -= 10;
                }
                else if (sr.sprite == closeLocker)
                {
                    transform.position -= new Vector3(0.27f, 0, 0);
                    col.offset += new Vector2(0.27f, 0);
                    sr.sprite = openLocker;
                    sr.sortingOrder += 10;
                    if (hasBox)
                    {
                        box.transform.position = transform.position + new Vector3(.25f, 0, 0);
                        hasBox = false;
                    }
                }
            }
        }
        else
        {
            if (player.hasKey)
            {
                locked = false;
                player.hasKey = false;
            }
            else
            {
                text.text = "I need a key!";
                StartCoroutine(wait());
            }
        }

    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
