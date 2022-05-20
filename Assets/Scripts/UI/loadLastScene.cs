using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLastScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void onClick()
    {

        SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
