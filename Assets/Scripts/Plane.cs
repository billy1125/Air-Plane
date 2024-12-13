using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float moveSpeed = 1; // 移動速度
    public GameObject BulletPrefab;
    public GameObject ExplosionPrefab;

    void FixedUpdate()
    {
        //簡單的左右控制，這個範例與過去的貓咪移動都是類似的
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x <= 2.5f)
                gameObject.transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x >= -2.5f)
                gameObject.transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y <= 5)
                gameObject.transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y >= -5)
                gameObject.transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
        }
    }

    void Update()
    {
        //增加子彈發射的功能
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = gameObject.transform.position + new Vector3(0, 0.6f, 0); //子彈生成的位置根據戰機的位置，再往上加0.6f
            Instantiate(BulletPrefab, pos, gameObject.transform.rotation); //依據上述的pos位置，生成子彈
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation); //在碰撞的位置產生爆炸

        if (collision.tag == "Enemy" || collision.tag == "EnemyBullet") //如果碰撞的標籤是Enemy
        {
            Destroy(gameObject); //刪除戰機物件
        }
    }
}