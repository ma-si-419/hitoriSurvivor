using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughEnemyController : MonoBehaviour
{
    Vector3 Player;
    GameObject Enemy;
    int enemyHP = 5;
    int damage = 1;
    bool isleftFlag;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃I�u�W�F�N�g���擾
        Enemy = GameObject.Find("player");

        enemyHP = 5;

        Player = new Vector2();

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�Ɍ������x�N�g���̍쐬
        Player = Enemy.transform.position - this.transform.position;
        Player = Player.normalized;
        //�������g���v���C���[�Ɍ����Ĉړ�
        this.transform.position += Player / 150;

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
        if (enemyHP == 0)
        {
            Destroy(this.gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //�U���ɓ��������G��1�_���[�W
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHP -= damage;
        }
    }
}
