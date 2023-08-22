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
        //プレイヤーのオブジェクトを取得
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

            //プレイヤーに向かうベクトルの作成
            Player = Enemy.transform.position - this.transform.position;
            Player = Player.normalized;
            //自分自身をプレイヤーに向けて移動
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
        if (isdamageFlag && count < 10)//ノックバック処理
        {
            this.transform.position -= Player * 5;
            count = 0;
            isdamageFlag = false;
        }
        //左右の向きを変える
        this.sprite.flipX = isleftFlag;

        //敵のHPが0になったとき消滅させる
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(EXPPrefab, transform.position, Quaternion.identity);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //攻撃に当たった敵にダメージ
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
