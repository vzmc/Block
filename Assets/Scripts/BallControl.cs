using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    public float moveSpeed = 10;    //Ballの速度
    public int life = 3;            //残機
    public Text lifeText;           //残機のTextUI
    public GameObject bar;          //Playerが操作するBar
    public Transform startPosition; //Ballの初期位置
    private Rigidbody2D rgbd2d;     //BallのRigidbody
    private Rigidbody2D barRgbd2d;  //BarのRigidbody
    private bool isStart;           //開始したかを判断するflag

    void Start()
    {
        isStart = false;
        transform.position = startPosition.position;
        lifeText.text = "x " + life.ToString();
        rgbd2d = GetComponent<Rigidbody2D>();
        barRgbd2d = bar.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isStart)
        {
            //開始してない状態に、Ballの位置を常にBar上の初期位置にする
            transform.position = startPosition.position;
        }
    }

    void FixedUpdate()
    {
        if (isStart)
        {
            //開始後、ボールの速度をmoveSpeedに維持する
            if (rgbd2d.velocity.sqrMagnitude != moveSpeed * moveSpeed)
            {
                rgbd2d.velocity = rgbd2d.velocity.normalized * moveSpeed;
            }
        }
        else
        {
            //開始してない状態に、"Jump"を押すと開始する
            if (Input.GetButtonDown("Jump"))
            {
                isStart = true;
                rgbd2d.velocity = new Vector2(0, 1) * moveSpeed;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isStart)
        {
            //Barと衝突する時、Barのvelocityと足し算して、Ballのvelocityを変更
            if (collision.gameObject.tag == "Player")
            {
                rgbd2d.velocity += barRgbd2d.velocity;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DeathZone")
        {
            //BallがDeathZoneに落ちると残機が減る
            life--;
            if (life < 0)
            {
                //もし残機がなくなると、GameOverになる
                PlayerPrefs.SetInt("IsClear", 0);
                MainControl.IsOver = true;
            }
            else
            {
                //まだ残機があると、未開始状態にして、残機Textを更新
                isStart = false;
                lifeText.text = "x " + life.ToString();
            }
        }
    }
}
