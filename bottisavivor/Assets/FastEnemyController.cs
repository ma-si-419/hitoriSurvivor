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
        //プレイヤーのオブジェクトを取得
        Enemy = GameObject.Find("player");


        Player = new Vector2();
        //プレイヤーに向かうベクトルの作成
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
        //左右の向きを変える
        this.GetComponent<SpriteRenderer>().flipX = isleftFlag;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //自分自身の座標をとる
        Enemypos = this.transform.position;
        //自分自身をプレイヤーに向けて移動
        this.transform.position += Player / FastEnemyMove;

        //敵のHPが0になったとき消滅させる
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(EXPPrefab, transform.position, Quaternion.identity);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }

        //マップ外に出たら消滅させる
        if (Enemypos.x < -300 || Enemypos.x > 300 || Enemypos.y < -200 || Enemypos.y > 200)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //攻撃に当たった敵に1ダメージ
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