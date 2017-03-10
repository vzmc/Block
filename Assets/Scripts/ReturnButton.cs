using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnButton : MonoBehaviour
{
    /// <summary>
    /// Title Sceneに戻る
    /// </summary>
    public void OnReturnButton()
    {
        SceneManager.LoadScene("Title");
    }
}
