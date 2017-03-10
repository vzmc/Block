using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    /// <summary>
    /// Main Sceneに入る
    /// </summary>
    public void OnStartButton()
    {
        SceneManager.LoadScene("Main");
    }
}
