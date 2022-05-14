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
        if (PlayerPrefs.GetInt("Unlocked") == 0)
        {
            PlayerPrefs.SetInt("Unlocked", 1);
        }
        SceneManager.LoadScene(LoadScene);
    }


    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
