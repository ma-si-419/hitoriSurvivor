using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughEnemyController : MonoBehaviour
{
    Vector3 Player;
    GameObject Enemy;
    public GameObject EXPPrefab;
    public GameObject DeathEffect;
    int enemyHP = 10;
    bool isleftFlag;
    bool isdamageFlag = false;
    public static int ToughEnemyMove = 150;
    int count;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃I�u�W�F�N�g���擾
        Enemy = GameObject.Find("player");

        enemyHP = 5;

        Player = new Vector2();

        sprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        count++;
    }
    // Update is called once per frame
    void Update()
    {
        //�v���C���[�Ɍ������x�N�g���̍쐬
        Player = Enemy.transform.position - this.transform.position;
        Player = Player.normalized;
        //�������g���v���C���[�Ɍ����Ĉړ�
        this.transform.position += Player / ToughEnemyMove;

        if (Player.x < 0)
        {
            isleftFlag = true;
        }
        else
        {
            isleftFlag = false;
        }
        //���E�̌�����ς���
        this.sprite.flipX = isleftFlag;
        if (isdamageFlag && count < 10)//�m�b�N�o�b�N����
        {
            this.transform.position -= Player * 10;
            count = 0;
            isdamageFlag = false;
        }
        //�G��HP��0�ɂȂ����Ƃ����ł�����
        if (enemyHP < 0)
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
            isdamageFlag = true;
            enemyHP -= EnemyController.damage;
        }
        else if (collision.gameObject.CompareTag("SubAttack"))
        {
            enemyHP -= 1;
        }
    }
}
