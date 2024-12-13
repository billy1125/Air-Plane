using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    public float MoveSpeed = 0.005f; //�ľ����t�׳]�w��

    public GameObject EnemyBulletPrefab; //�ľ��l�u�w�m����
    GameObject GameManager; //�C���޲z�{��

    public float span = 0.5f;
    public float delta = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager"); //�����������C���޲z�{��
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += new Vector3(0, -1 * MoveSpeed, 0); 
        transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime); //�ľ��|���_���U���ʡA�ϥ�Translate
    }

    void Update()
    {
        // ���_�����ľ���m�A�p�G�C��y�b-6�A�N�R���ۤv
        if (transform.position.y < -6)
            Destroy(gameObject);

        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            Vector3 pos = gameObject.transform.position + new Vector3(0, -0.5f, 0);
            //�l�u�ͦ�����m�ھڼľ�����m�A�A���U��0.5f
            Instantiate(EnemyBulletPrefab, pos, gameObject.transform.rotation); //�̾ڤW�z��pos��m�A�ͦ��l�u
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet") //�p�G�I�������ҬOBullet
        {
            GameManager.GetComponent<GameManager>().IncreaseScore(10); //�p�G����ľ��A�N�[10��
            Destroy(gameObject); //�R���ľ�����
        }
    }
}
