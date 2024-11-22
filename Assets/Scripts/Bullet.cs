using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1; // 移動速度

    void Start()
    {
        Destroy(gameObject, 2); //設定2秒後子彈物件被刪除
    }

    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime; //子彈會不斷往上移動
    }
}