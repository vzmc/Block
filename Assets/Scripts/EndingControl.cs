using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingControl : MonoBehaviour
{
    private Text titleText;
    void Start()
    {
        titleText = GetComponent<Text>();

        //ゲームの結果を判断し、対応の文字を表示
        if(PlayerPrefs.GetInt("IsClear") == 1)
        {
            titleText.text = "Game Clear";
        }
        else
        {
            titleText.text = "Game Over";
        }
    }
}
