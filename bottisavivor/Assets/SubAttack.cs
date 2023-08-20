using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SubAttack : MonoBehaviour
{
    //武器選択ボタンの追加
    public GameObject SelectButton1;
    public GameObject SelectButton2;
    //イメージの追加
    public GameObject image;
    public int span = 0;
    public GameObject SubAttack1;
    Vector3 Mousepos;//マウスの位置
    Vector3 Playerpos;//プレイヤーの位置
    Vector3 Attackpos;//攻撃の位置
    
    float speed;

    void Start()
    {
        speed = 75.0f;  // 弾の速度
    }
    void FixedUpdate()
    {
        if (SubSelectButton1.SubAttackCount == 1)
        {
            Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの座標をとる
            Playerpos = this.transform.position;                           //プレイヤーの座標をとる
            Attackpos.x = Mousepos.x - Playerpos.x;//Ｘ座標の計算
            Attackpos.y = Mousepos.y - Playerpos.y;//Ｙ座標の計算
            if (span > 60)
            {
                GameObject clone = Instantiate(SubAttack1, transform.position, Quaternion.identity);

                // クリックした座標の取得（スクリーン座標からワールド座標に変換）
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // 向きの生成（Z成分の除去と正規化）
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // 弾に速度を与える
                clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
                span = 0;
            }
            span++;
        }
        else if (SubSelectButton1.SubAttackCount == 2)
        {
            if (span > 50)
            {
                GameObject clone = Instantiate(SubAttack1, transform.position, Quaternion.identity);

                // クリックした座標の取得（スクリーン座標からワールド座標に変換）
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // 向きの生成（Z成分の除去と正規化）
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // 弾に速度を与える
                clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
                span = 0;
            }
            span++;
        }
        else if (SubSelectButton1.SubAttackCount == 3)
        {
            if (span > 40)
            {
                GameObject clone = Instantiate(SubAttack1, transform.position, Quaternion.identity);

                // クリックした座標の取得（スクリーン座標からワールド座標に変換）
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // 向きの生成（Z成分の除去と正規化）
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // 弾に速度を与える
                clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
                span = 0;
            }
            span++;
        }
        else if (SubSelectButton1.SubAttackCount == 4)
        {
            if (span > 30)
            {
                GameObject clone = Instantiate(SubAttack1, transform.position, Quaternion.identity);

                // クリックした座標の取得（スクリーン座標からワールド座標に変換）
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // 向きの生成（Z成分の除去と正規化）
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // 弾に速度を与える
                clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
                span = 0;
            }
            span++;
        }
        else if (SubSelectButton1.SubAttackCount >= 5)
        {
            if (span > 20)
            {
                GameObject clone = Instantiate(SubAttack1, transform.position, Quaternion.identity);

                // クリックした座標の取得（スクリーン座標からワールド座標に変換）
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // 向きの生成（Z成分の除去と正規化）
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // 弾に速度を与える
                clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
                span = 0;
            }
            span++;
        }
    }
    
}
