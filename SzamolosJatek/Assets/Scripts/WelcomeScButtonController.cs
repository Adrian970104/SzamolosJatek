using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScButtonController : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
