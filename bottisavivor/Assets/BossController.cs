using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public GameObject Bullet;
    Vector3 Player;
    GameObject Enemy;
    Vector3 Enemypos;
    Vector3 Bulletpos;
    public GameObject DeathBoss;
    int enemyHP = 20;
    int damage = 2;
    int count = 0;
    bool isleftFlag;
    public static int BossStop = 1;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃I�u�W�F�N�g���擾
        Enemy = GameObject.Find("player");


        Player = new Vector2();

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
        this.sprite.flipX = isleftFlag;
        if (count == 10)
        {
            //�v���C���[�Ɍ������x�N�g���̍쐬
            Player = Enemy.transform.position - this.transform.position;
            Player = Player.normalized;
            Player *= -1;

        }
        else if (count < 100)
        {
            //�������v���C���[���痣���i�����̂悤�Ȃ��́j
            this.transform.position += Player / 50 / BossStop;

            //���E�̌�����ς���
            if (Player.x > 0)
            {
                isleftFlag = true;
            }
            else
            {
                isleftFlag = false;
            }
            this.sprite.flipX = isleftFlag;
        }
        else if (count == 100)
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
            this.sprite.flipX = isleftFlag;
            //�v���C���[�ɑ΂��ēːi����
            this.transform.position += Player * 2 / BossStop;
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
                this.sprite.flipX = isleftFlag;
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
                this.sprite.flipX = isleftFlag;
            }
            if (count % 30 == 0)
            {
                //�{�X�̍��W���Ƃ�
                Bulletpos = Enemypos;
                //�����_���ȕ����ɋ����o��
                Bulletpos = new Vector3(Bulletpos.x + Random.Range(-1, 2), Bulletpos.y + Random.Range(-1, 2), 0);
                Instantiate(Bullet, Bulletpos, Quaternion.identity);
            }
            if(count > 200)
            {
                count = 0;
            }
        }


        //�G��HP��0�ɂȂ����Ƃ����ł�����
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(DeathBoss, transform.position, Quaternion.identity);
        }

        if (enemyHP <= 0)
        {
            SceneManager.LoadScene("GameClearScene");
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //�U���ɓ��������G�Ƀ_���[�W
        if (collision.gameObject.CompareTag("Attack"))
        {
            enemyHP -= damage;
        }
        else if (collision.gameObject.CompareTag("SubAttack"))
        {
            enemyHP -= 1;
        }
    }
}
