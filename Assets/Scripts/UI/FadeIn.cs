using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public Image image;
    public float fadetime;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {


        Color color = image.color;
        color.a = Mathf.Clamp((Time.time - spawnTime) * fadetime, 0, 1);
        image.color = color;
        if ((Time.time - spawnTime) * fadetime > 1)
        {
            if(!(SceneManager.GetActiveScene().name == "Credits"))
            {
                print(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("Credits");
            }
        }
    }
}
