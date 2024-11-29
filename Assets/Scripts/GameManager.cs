using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyAirplanePrefab; //戰機預置物件
    public float span = 1.0f;
    public float delta = 0;

    void Update()
    {
        //以下我們參考之前做的貓咪忍者遊戲，想想看如何拿箭頭產生的程式，修改成為外星怪物的產生程式
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            float px = Random.Range(-3.0f, 3.0f); // 這次我們產生的是-3到3之間的浮點數
            Instantiate(EnemyAirplanePrefab, new Vector3(px, 7, 0), Quaternion.identity);
        }
    }
}