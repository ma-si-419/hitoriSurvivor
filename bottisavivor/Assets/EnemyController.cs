using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Vector3 Player;
    GameObject Enemy;
    int enemyHP = 3;
    public static  int damage = 1;
    public GameObject EXPPrefab;
    public GameObject DeathEffect;
    bool isleftFlag;
    public static int EnemyMove = 80;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃I�u�W�F�N�g���擾
        Enemy = GameObject.Find("player");


        Player = new Vector2();

    }


    // Update is called once per frame
    void Update()
    {


        //�v���C���[�Ɍ������x�N�g���̍쐬
        Player = Enemy.transform.position - this.transform.position;
        Player = Player.normalized;
        //�������g���v���C���[�Ɍ����Ĉړ�
        this.transform.position += Player / EnemyMove;
        if (Player.x < 0)
        {
            isleftFlag = true;
        }
        else
        {
            isleftFlag = false;
        }
        //���E�̌�����ς���
        this.GetComponent<SpriteRenderer>().flipX = isleftFlag;

        //�G��HP��0�ɂȂ����Ƃ����ł�����
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(EXPPrefab, transform.position, Quaternion.identity);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //�U���ɓ��������G��1�_���[�W
        if (collision.gameObject.CompareTag("Attack"))
        {
            enemyHP -= damage;
        }
    }


}
