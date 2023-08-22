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
        //プレイヤーのオブジェクトを取得
        Enemy = GameObject.Find("player");


        Player = new Vector2();

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //敵の座標を獲得する
        Enemypos = this.transform.position;
        count++;
        //左右の向きを変える
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
            //プレイヤーに向かうベクトルの作成
            Player = Enemy.transform.position - this.transform.position;
            Player = Player.normalized;
            Player *= -1;

        }
        else if (count < 100)
        {
            //ゆっくりプレイヤーから離れる（助走のようなもの）
            this.transform.position += Player / 50 / BossStop;

            //左右の向きを変える
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
            //プレイヤーに向かうベクトルの作成
            Player = Enemy.transform.position - this.transform.position;
            Player = Player.normalized;
        }
        else
        {
            //左右の向きを変える
            if (Player.x < 0)
            {
                isleftFlag = true;
            }
            else
            {
                isleftFlag = false;
            }
            this.sprite.flipX = isleftFlag;
            //プレイヤーに対して突進する
            this.transform.position += Player * 2 / BossStop;
            //マップ外に出そうになったら跳ね返る
            if (Enemypos.x < -200 || Enemypos.x > 200)
            {
                Player.x *= -1;
                Player = Enemy.transform.position - this.transform.position;
                Player = Player.normalized;
                //左右の向きを変える
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
                //左右の向きを変える
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
                //ボスの座標をとる
                Bulletpos = Enemypos;
                //ランダムな方向に球を出す
                Bulletpos = new Vector3(Bulletpos.x + Random.Range(-1, 2), Bulletpos.y + Random.Range(-1, 2), 0);
                Instantiate(Bullet, Bulletpos, Quaternion.identity);
            }
            if(count > 200)
            {
                count = 0;
            }
        }


        //敵のHPが0になったとき消滅させる
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
        //攻撃に当たった敵にダメージ
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
