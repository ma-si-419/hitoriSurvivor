using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public int span = 0;
    public GameObject AttackEffect;
    GameObject Attack;
    Vector3 Addpos;//マウスの位置
    Vector3 Playerpos;//プレイヤーの位置
    Vector3 Attackpos;//攻撃の位置
    Vector3 AttackLog;//保存する攻撃の位置
    int time;
    bool isup;
    bool isdown;
    bool isright;
    bool isleft;
    bool isButton;

    void FixedUpdate()
    {
        Debug.Log(isButton);
        //Debug.Log(isup);
        //Debug.Log(isdown);
        //Debug.Log(isright);
        //Debug.Log(isleft);
        //Debug.Log("通ってる");

        //        Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの座標をとる
        Playerpos = this.transform.position;                           //プレイヤーの座標をとる
        if (span > 50)
        {
            isButton = false;
            Attack = Instantiate(AttackEffect) as GameObject;
            if (Input.GetKey("w") || Input.GetKey("up"))//真上に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));//0回転
                Addpos.y = 20;
                isup = true;
                isButton = true;
            }
            if (Input.GetKey("a") || Input.GetKey("left"))//左に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 90));//90度回転
                Addpos.x = -20;
                isleft = true;
                isButton = true;
            }
            if (Input.GetKey("s") || Input.GetKey("down"))//真下に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 180));//180度回転
                Addpos.y = -20;
                isdown = true;
                isButton = true;
            }
            if (Input.GetKey("d") || Input.GetKey("right"))//右に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 270));//270度回転
                Addpos.x = 20;
                isright = true;
                isButton = true;
            }
            if (isup && isleft)//左上に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 315));//315度回転
            }
            else if (isleft && isdown)//左下に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 225));//225度回転
            }
            else if (isright && isdown)//右下に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 135));//135度回転
            }
            else if (isright && isup)//右上に攻撃する場合
            {
                Attack.transform.Rotate(new Vector3(0, 0, 45));//45度回転
            }
            if (!isButton)
            {
                AttackLog = new Vector3(Addpos.x + Playerpos.x, Addpos.y + Playerpos.y, 0);
                Attack.transform.position = new Vector3(Addpos.x + Playerpos.x, Addpos.y + Playerpos.y, 0);
                Addpos = new Vector3(0, 0, 0);
                isup = false;
                isdown = false;
                isright = false;
                isleft = false;
            }
            else
            {
                Attack.transform.position = new Vector3(Addpos.x + Playerpos.x, Addpos.y + Playerpos.y, 0);
            }
            span = 0;
        }
        span++;

    }
}
