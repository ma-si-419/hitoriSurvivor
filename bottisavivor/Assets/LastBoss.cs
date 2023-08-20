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

        //プレイヤーのオブジェクトを取得
        Enemy = GameObject.Find("player");

    }

    void FixedUpdate()
    {
        if (count == 100)
        {
            RandomNum = Random.Range(1, 3);
        }
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
        this.GetComponent<SpriteRenderer>().flipX = isleftFlag;
        if (RandomNum < 2)
        {

            //ゆっくりプレイヤーから離れる（助走のようなもの)
            if(count > 150)
            {
            this.transform.position += Player / 50;
            }

            //左右の向きを変える
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
                this.GetComponent<SpriteRenderer>().flipX = isleftFlag;

                this.transform.position += Player * 2;
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
                    this.GetComponent<SpriteRenderer>().flipX = isleftFlag;
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

