using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Vector3 Enemypos;
    Vector3 Boss;
    GameObject Enemy;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのオブジェクトを取得
        Enemy = GameObject.Find("player");


        Boss = new Vector3();
        //ボスの座標と自分の座標をとり、ボスと自分の座標を離れていくように処理する
        Boss = Enemy.transform.position - this.transform.position;
        Boss = Boss.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        Enemypos = this.transform.position;

        //プレイヤーに向かって飛んでいく
        this.transform.position += Boss / 10;

        //敵の座標がマップ外に出たら消滅させる
        if (Enemypos.x > 200 || Enemypos.x < -200 || Enemypos.y > 100 || Enemypos.y < -100)
        {
            Destroy(this.gameObject);
        }
        //ボスと完全に同じ位置に出た場合消滅させる
        if(Enemypos == Boss)
        {
            Destroy(this.gameObject);
        }
        //弾が止まってしまった場合消す
        if(count == 2000)
        {
            Destroy(this.gameObject);
        }
    }
}