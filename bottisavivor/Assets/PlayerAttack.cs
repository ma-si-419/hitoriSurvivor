using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public int span = 0;
    public GameObject AttackEffect;
    GameObject Attack;
    Vector3 Mousepos;//マウスの位置
    Vector3 Playerpos;//プレイヤーの位置
    Vector3 Attackpos;//攻撃の位置
    int time;

    void FixedUpdate()
    {
        Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの座標をとる
        Playerpos = this.transform.position;                           //プレイヤーの座標をとる
        Attackpos.x = Mousepos.x - Playerpos.x;//Ｘ座標の計算
        Attackpos.y = Mousepos.y - Playerpos.y;//Ｙ座標の計算
        if (span > 50)
        {
            
            Attack = Instantiate(AttackEffect) as GameObject;
            if (Attackpos.x < 25  && Attackpos.x > -25 && Attackpos.y > 0)//真上に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));//0回転
            }
            if (Attackpos.x < 0 && Attackpos.y < 25 && Attackpos.y > -25)//左に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 90));//90度回転
            }
            if (Attackpos.x < 25 && Attackpos.x > -25 && Attackpos.y < 0)//真下に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 180));//180度回転
            }
            if (Attackpos.x > 0 && Attackpos.y < 25 && Attackpos.y > -25)//右に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 270));//270度回転
            }
            if (Attackpos.x < -25 && Attackpos.y > 25)//左上に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 45));//45度回転
            }
            if (Attackpos.x < -25 && Attackpos.y < -25)//左下に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 135));//135度回転
            }
            if (Attackpos.x > 25 && Attackpos.y < -25)//右下に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 225));//225度回転
            }
            if (Attackpos.x > 25 && Attackpos.y > 25)//右上に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 315));//315度回転
            }
            Attack.transform.position = new Vector3 (Attackpos.x / 10 + Playerpos.x, Attackpos.y / 10 + Playerpos.y, 0);

            span = 0;
        }
        span++;

    }
}
