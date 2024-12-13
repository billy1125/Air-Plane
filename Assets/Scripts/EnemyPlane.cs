using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    public float MoveSpeed = 0.005f; //敵機的速度設定值

    public GameObject EnemyBulletPrefab; //敵機子彈預置物件
    GameObject GameManager; //遊戲管理程式

    public float span = 0.5f;
    public float delta = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager"); //找到場景中的遊戲管理程式
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

        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            Vector3 pos = gameObject.transform.position + new Vector3(0, -0.5f, 0);
            //子彈生成的位置根據敵機的位置，再往下減0.5f
            Instantiate(EnemyBulletPrefab, pos, gameObject.transform.rotation); //依據上述的pos位置，生成子彈
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet") //如果碰撞的標籤是Bullet
        {
            GameManager.GetComponent<GameManager>().IncreaseScore(10); //如果打到敵機，就加10分
            Destroy(gameObject); //刪除敵機物件
        }
    }
}
