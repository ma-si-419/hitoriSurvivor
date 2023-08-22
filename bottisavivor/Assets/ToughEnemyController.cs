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
        //プレイヤーのオブジェクトを取得
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
        //プレイヤーに向かうベクトルの作成
        Player = Enemy.transform.position - this.transform.position;
        Player = Player.normalized;
        //自分自身をプレイヤーに向けて移動
        this.transform.position += Player / ToughEnemyMove;

        if (Player.x < 0)
        {
            isleftFlag = true;
        }
        else
        {
            isleftFlag = false;
        }
        //左右の向きを変える
        this.sprite.flipX = isleftFlag;
        if (isdamageFlag && count < 10)//ノックバック処理
        {
            this.transform.position -= Player * 10;
            count = 0;
            isdamageFlag = false;
        }
        //敵のHPが0になったとき消滅させる
        if (enemyHP < 0)
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
            isdamageFlag = true;
            enemyHP -= EnemyController.damage;
        }
        else if (collision.gameObject.CompareTag("SubAttack"))
        {
            enemyHP -= 1;
        }
    }
}
