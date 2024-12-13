using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyAirplanePrefab; //戰機預置物件
    public float span = 1.0f;
    public float delta = 0;

    int intScore = 0;
    public Text ScoreText;

    public GameObject StarFighterPrefab; //戰機預置物件
    public GameObject StartPoint; //戰機產生的起點

    GameObject StarFighter;
    bool IsRestarting = false; //遊戲是不是正在重啟中？True代表遊戲正在重啟，False代表遊戲正常執行中

    void Start()
    {
        ScoreText.text = "分數：0"; //初始化分數表
        InitialStarFighter(); //初始化戰機
    }

    void Update()
    {
        //以下我們參考之前做的貓咪忍者遊戲，想想看如何拿箭頭產生的程式，修改成為外星怪物的產生程式
        this.delta += Time.deltaTime;
        if (this.delta > this.span && IsRestarting == false)
        {
            this.delta = 0;
            float px = Random.Range(-3.0f, 3.0f); // 這次我們產生的是-3到3之間的浮點數
            Instantiate(EnemyAirplanePrefab, new Vector3(px, 7, 0), Quaternion.identity);
        }

        //修正：我們多加一個條件，只有在「戰機被刪除」和「遊戲正常執行中」的兩個條件都成立之下，才開始遊戲重啟
        //避免因為不斷Update，所以不斷產生戰機，最後造成遊戲崩潰...
        //同時也設計一個緩衝時間，五秒內都不會有怪物產生，避免還有怪物時就產生戰機
        if (StarFighter == null && IsRestarting == false)
        {
            IsRestarting = true; //設定「遊戲正在重啟」的狀態
            StartCoroutine(StartGame()); //開始重啟遊戲
        }
    }

    // 加分的方法（同學要複習一下C#函式與怎麼設定函式參數）
    public void IncreaseScore(int _score)
    {
        intScore += _score;
        ScoreText.text = "分數：" + intScore;
    }

    //初始化戰機的方法
    public void InitialStarFighter()
    {
        intScore = 0;
        IncreaseScore(intScore);
        StarFighter = Instantiate(StarFighterPrefab, StartPoint.transform.position, StartPoint.transform.rotation);
        IsRestarting = false; //遊戲重啟完成，則將「遊戲正在重啟」的狀態取消，改為「遊戲正常執行中」
    }

    // 一個 IEnumerator 介面，用來設定一個重啟遊戲的計時器
    IEnumerator StartGame()
    {
        if (StarFighterPrefab == null)
        {
            yield break;
        }

        yield return new WaitForSeconds(5); //計時五秒後（也就是遊戲五秒之後，要執行下面的方法）

        InitialStarFighter(); //五秒後，要初始化戰機
    }
}