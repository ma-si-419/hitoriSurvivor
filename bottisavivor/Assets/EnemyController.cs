using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Vector3 Player;
    GameObject Enemy;
    int enemyHP = 4;
    public static int damage = 2;
    public GameObject EXPPrefab;
    public GameObject DeathEffect;
    bool isleftFlag;
    public static int EnemyMove = 80;
    bool isdamageFlag;
    int count;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃I�u�W�F�N�g���擾
        Enemy = GameObject.Find("player");


        Player = new Vector2();

        sprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (isdamageFlag)
        {
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isdamageFlag)
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
        }
        if (isdamageFlag && count < 10)//�m�b�N�o�b�N����
        {
            this.transform.position -= Player * 5;
            count = 0;
            isdamageFlag = false;
        }
        //���E�̌�����ς���
        this.sprite.flipX = isleftFlag;

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
        //�U���ɓ��������G�Ƀ_���[�W
        if (collision.gameObject.CompareTag("Attack"))
        {
            isdamageFlag = true;
            enemyHP -= damage;
        }
        else if (collision.gameObject.CompareTag("SubAttack"))
        {
            enemyHP -= 1;
        }
    }


}
