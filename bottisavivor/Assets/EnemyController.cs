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
        //プレイヤーのオブジェクトを取得
        Enemy = GameObject.Find("player");


        Player = new Vector2();

    }


    // Update is called once per frame
    void Update()
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
        //左右の向きを変える
        this.GetComponent<SpriteRenderer>().flipX = isleftFlag;

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
        //攻撃に当たった敵に1ダメージ
        if (collision.gameObject.CompareTag("Attack"))
        {
            enemyHP -= damage;
        }
    }


}
