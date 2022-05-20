using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Image keyImage;
    private PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasKey)
        {
            keyImage.enabled = true;
        }
        else
        {
            keyImage.enabled = false;
        }
    }
}
