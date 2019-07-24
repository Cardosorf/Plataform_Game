using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsMenuButtons : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    

    public void Quit()
    {
        Application.Quit();
    }
}
