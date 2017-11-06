using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
    void Start()
    {
    }

    public void ButtonPlay()
    {
		//MyLoading.LoadLevel("Game");
		SceneManager.LoadScene ("Game");
    }

    public void ButtonBackToMenu()
    {
        //MyLoading.LoadLevel("Menu");
		SceneManager.LoadScene ("Menu");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
