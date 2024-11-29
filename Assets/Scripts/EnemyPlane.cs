using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    public float MoveSpeed = 0.005f; //敵機的速度設定值

    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, 2); // 也可以用設定時間的方式來控制敵機是否刪除
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += new Vector3(0, -1 * MoveSpeed, 0); 
        transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime); //敵機會不斷往下移動，使用Translate
    }

    void Update()
    {
        // 不斷偵測敵機位置，如果低於y軸-6，就刪除自己
        if (transform.position.y < -6)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet") //如果碰撞的標籤是Bullet
        {
            Destroy(gameObject); //刪除敵機物件
        }
    }
}