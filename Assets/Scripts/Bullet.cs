using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1; // ���ʳt��

    void Start()
    {
        Destroy(gameObject, 2); //�]�w2���l�u����Q�R��
    }

    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime; //�l�u�|���_���W����
    }
}