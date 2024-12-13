using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject ExplosionPrefab; // 爆炸預置物件

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2); //設定2秒後子彈物件被刪除
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -5, 0) * Time.deltaTime; //子彈會不斷往下移動
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // 碰到Player標籤則產生爆炸
        {
            Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}