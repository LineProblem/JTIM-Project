using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelevt : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool touching = false;
    public int num;
    public string level;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        touching = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        touching = false;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (touching)
        {
            if (PlayerPrefs.GetInt("Unlocked") >= num)
            {
                SceneManager.LoadScene(level);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
