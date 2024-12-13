using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyAirplanePrefab; //�Ծ��w�m����
    public float span = 1.0f;
    public float delta = 0;

    int intScore = 0;
    public Text ScoreText;

    public GameObject StarFighterPrefab; //�Ծ��w�m����
    public GameObject StartPoint; //�Ծ����ͪ��_�I

    GameObject StarFighter;
    bool IsRestarting = false; //�C���O���O���b���Ҥ��HTrue�N��C�����b���ҡAFalse�N��C�����`���椤

    void Start()
    {
        ScoreText.text = "���ơG0"; //��l�Ƥ��ƪ�
        InitialStarFighter(); //��l�ƾԾ�
    }

    void Update()
    {
        //�H�U�ڭ̰ѦҤ��e�����߫}�Ԫ̹C���A�Q�Q�ݦp�󮳽b�Y���ͪ��{���A�ק令���~�P�Ǫ������͵{��
        this.delta += Time.deltaTime;
        if (this.delta > this.span && IsRestarting == false)
        {
            this.delta = 0;
            float px = Random.Range(-3.0f, 3.0f); // �o���ڭ̲��ͪ��O-3��3�������B�I��
            Instantiate(EnemyAirplanePrefab, new Vector3(px, 7, 0), Quaternion.identity);
        }

        //�ץ��G�ڭ̦h�[�@�ӱ���A�u���b�u�Ծ��Q�R���v�M�u�C�����`���椤�v����ӱ��󳣦��ߤ��U�A�~�}�l�C������
        //�קK�]�����_Update�A�ҥH���_���;Ծ��A�̫�y���C���Y��...
        //�P�ɤ]�]�p�@�ӽw�Įɶ��A���������|���Ǫ����͡A�קK�٦��Ǫ��ɴN���;Ծ�
        if (StarFighter == null && IsRestarting == false)
        {
            IsRestarting = true; //�]�w�u�C�����b���ҡv�����A
            StartCoroutine(StartGame()); //�}�l���ҹC��
        }
    }

    // �[������k�]�P�ǭn�Ʋߤ@�UC#�禡�P���]�w�禡�Ѽơ^
    public void IncreaseScore(int _score)
    {
        intScore += _score;
        ScoreText.text = "���ơG" + intScore;
    }

    //��l�ƾԾ�����k
    public void InitialStarFighter()
    {
        intScore = 0;
        IncreaseScore(intScore);
        StarFighter = Instantiate(StarFighterPrefab, StartPoint.transform.position, StartPoint.transform.rotation);
        IsRestarting = false; //�C�����ҧ����A�h�N�u�C�����b���ҡv�����A�����A�אּ�u�C�����`���椤�v
    }

    // �@�� IEnumerator �����A�Ψӳ]�w�@�ӭ��ҹC�����p�ɾ�
    IEnumerator StartGame()
    {
        if (StarFighterPrefab == null)
        {
            yield break;
        }

        yield return new WaitForSeconds(5); //�p�ɤ����]�]�N�O�C��������A�n����U������k�^

        InitialStarFighter(); //�����A�n��l�ƾԾ�
    }
}