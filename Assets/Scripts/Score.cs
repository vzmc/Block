using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Text text;            //Scoreを表示するText
    public Transform Blocks;            //Blockの親Transform
    private static int score = 0;       //現在のScore
    private static int blockCount = 0;  //Blockの総数

    private void Start()
    {
        //Blockの総数を取得
        blockCount = Blocks.childCount; 
        score = 0;
        text = GetComponent<Text>();
    }

    /// <summary>
    /// Scoreを加算
    /// </summary>
    /// <param name="s"></param>
    public static void AddScore(int s)
    {
        score += s;
        text.text = "Score : " + score;

        //Blockが全部破壊された場合、Clearを表示
        if(score >= blockCount)
        {
            PlayerPrefs.SetInt("IsClear", 1);
            MainControl.IsOver = true;
        }
    }
}
