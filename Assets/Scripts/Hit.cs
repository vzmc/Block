using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject HitEffect;
    private BoxCollider2D boxCollider2d;

    private void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //Zを入力すると、コライダーをTriggerにして、弾が貫通弾に見せる
        if (Input.GetKeyDown(KeyCode.Z))
        {
            boxCollider2d.isTrigger = !boxCollider2d.isTrigger;
        }
    }

    /// <summary>
    /// BallがBlockとぶつかった時の処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Instantiate(HitEffect, transform.position, transform.rotation);
            Score.AddScore(1);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// BallがBlockとぶつかった時の処理（貫通弾の場合）
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Instantiate(HitEffect, transform.position, transform.rotation);
            Score.AddScore(1);
            Destroy(gameObject);
        }
    }
}
