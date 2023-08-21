using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyController : MonoBehaviour
{
    
    Vector3 Player;
    GameObject Enemy;
    int enemyHP = 2;
    bool isleftFlag;
    public static int FastEnemyMove = 1;
    Vector3 Enemypos;
    public GameObject EXPPrefab;
    public GameObject DeathEffect;
    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃I�u�W�F�N�g���擾
        Enemy = GameObject.Find("player");


        Player = new Vector2();
        //�v���C���[�Ɍ������x�N�g���̍쐬
        Player = Enemy.transform.position - this.transform.position;
        Player = Player.normalized;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�������g�̍��W���Ƃ�
        Enemypos = this.transform.position;
        //�������g���v���C���[�Ɍ����Ĉړ�
        this.transform.position += Player / FastEnemyMove;

        //�G��HP��0�ɂȂ����Ƃ����ł�����
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(EXPPrefab, transform.position, Quaternion.identity);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }

        //�}�b�v�O�ɏo������ł�����
        if (Enemypos.x < -300 || Enemypos.x > 300 || Enemypos.y < -200 || Enemypos.y > 200)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //�U���ɓ��������G��1�_���[�W
        if (collision.gameObject.CompareTag("Attack"))
        {
            enemyHP -= EnemyController.damage;
        }
        else if (collision.gameObject.CompareTag("SubAttack"))
        {
            enemyHP -= 1;
        }
    }
}