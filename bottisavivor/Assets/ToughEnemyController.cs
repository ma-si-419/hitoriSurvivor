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
        //プレイヤーのオブジェクトを取得
        Enemy = GameObject.Find("player");

        enemyHP = 5;

        Player = new Vector2();

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーに向かうベクトルの作成
        Player = Enemy.transform.position - this.transform.position;
        Player = Player.normalized;
        //自分自身をプレイヤーに向けて移動
        this.transform.position += Player / 150;

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
        if (enemyHP == 0)
        {
            Destroy(this.gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //攻撃に当たった敵に1ダメージ
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHP -= damage;
        }
    }
}
