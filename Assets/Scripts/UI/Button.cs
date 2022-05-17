using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField]
    public string LoadScene;
    public void SceneChanger()
    {
        Debug.Log("button pressed");
        SceneManager.LoadScene(LoadScene);
    }


    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
