using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastBoss : MonoBehaviour
{
    Animator animator;
    Vector3 Player;
    GameObject Enemy;
    Vector3 Enemypos;
    public GameObject DeathBoss;
    public GameObject BossAttack;
    int BossHp = 10;
    bool isleftFlag;
    int RandomNum;
    int nowAnim;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //�v���C���[�̃I�u�W�F�N�g���擾
        Enemy = GameObject.Find("player");

    }

    void FixedUpdate()
    {
        if (count == 100)
        {
            RandomNum = Random.Range(1, 3);
        }
        //�G�̍��W���l������
        Enemypos = this.transform.position;
        count++;
        //���E�̌�����ς���
        if (Player.x > 0)
        {
            isleftFlag = true;
        }
        else
        {
            isleftFlag = false;
        }
        this.GetComponent<SpriteRenderer>().flipX = isleftFlag;
        if (RandomNum < 2)
        {

            //�������v���C���[���痣���i�����̂悤�Ȃ���)
            if(count > 150)
            {
            this.transform.position += Player / 50;
            }

            //���E�̌�����ς���
            if (Player.x > 0)
            {
                isleftFlag = true;
            }
            else
            {
                isleftFlag = false;
            }
            this.GetComponent<SpriteRenderer>().flipX = isleftFlag;
            if (count == 150)
            {
                //�v���C���[�Ɍ������x�N�g���̍쐬
                Player = Enemy.transform.position - this.transform.position;
                Player = Player.normalized;
            }
            else
            {
                //���E�̌�����ς���
                if (Player.x < 0)
                {
                    isleftFlag = true;
                }
                else
                {
                    isleftFlag = false;
                }
                this.GetComponent<SpriteRenderer>().flipX = isleftFlag;

                this.transform.position += Player * 2;
                //�}�b�v�O�ɏo�����ɂȂ����璵�˕Ԃ�
                if (Enemypos.x < -200 || Enemypos.x > 200)
                {
                    Player.x *= -1;
                    Player = Enemy.transform.position - this.transform.position;
                    Player = Player.normalized;
                    //���E�̌�����ς���
                    if (Player.x > 0)
                    {
                        isleftFlag = true;
                    }
                    else
                    {
                        isleftFlag = false;
                    }
                    this.GetComponent<SpriteRenderer>().flipX = isleftFlag;
                }
                if (Enemypos.y < -100 || Enemypos.y > 100)
                {
                    Player.y *= -1;
                    Player = Enemy.transform.position - this.transform.position;
                    Player = Player.normalized;
                    //���E�̌�����ς���
                    if (Player.x > 0)
                    {
                        isleftFlag = true;
                    }
                    else
                    {
                        isleftFlag = false;
                    }
                    this.GetComponent<SpriteRenderer>().flipX = isleftFlag;
                    if (count > 400)
                    {
                        RandomNum = 0;
                    }
                }
            }

        }
        if (RandomNum > 2)
        {

            if (count == 150)
            {
                nowAnim = 1;
            }
            if (count == 200)
            {
                Enemypos = this.transform.position;
                Instantiate(BossAttack, Enemypos, Quaternion.identity);
            }
            if (count == 250)
            {
                RandomNum = 0;
                nowAnim = 0;
            }

        }


    }



    void Update()
    {
        animator.SetInteger("Attack", nowAnim);
        if (BossHp < 0)
        {
            SceneManager.LoadScene("GameClearScene");
        }
    }
}

