using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainControl : MonoBehaviour
{
    public static bool IsOver;

    void Start()
    {
        IsOver = false;
    }

    void Update()
    {
        if (IsOver)
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
