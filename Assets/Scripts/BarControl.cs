using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarControl : MonoBehaviour
{
    public float moveSpeed = 5;     //移動速度
    private Rigidbody2D rgbd2d;     //Rigidbody
    private Vector2 moveControl;    //コントロール用のvector
    
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        moveControl = new Vector2(0, 0);
    }

    void Update()
    {
        //Barのコントロール
        moveControl.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        //Rigidbodyを更新
        rgbd2d.velocity = moveControl * moveSpeed;
    }
}
