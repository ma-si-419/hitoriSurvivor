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
    bool isleftFlag;
    bool isupFlag;
    bool isrightFlag;
    bool isdownFlag;
    void FixedUpdate()
    {
        Playerpos = this.transform.position;                           //プレイヤーの座標をとる
        if (span > 50)
        {
            Attack = Instantiate(AttackEffect) as GameObject;

            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                isrightFlag = false;
                isleftFlag = true;
            }
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                isleftFlag = false;
                isrightFlag = true;
            }
            if(Input.GetKey("w") || Input.GetKey("up"))
            {
                isdownFlag = false;
                isupFlag = true;
            }
            if (Input.GetKey("s") || Input.GetKey("down"))
            {
                isupFlag = false;
                isdownFlag = true;
            }
            if (isleftFlag && isupFlag)//左上
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 45));
                Attack.transform.position = new Vector3(Playerpos.x - 20, Playerpos.y + 20, 0);
            }
            else if (isleftFlag == false && isrightFlag == false &&isupFlag)//上
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.position = new Vector3(Playerpos.x, Playerpos.y + 20, 0);
            }
            else if(isrightFlag && isupFlag)//右上
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 315));
                Attack.transform.position = new Vector3(Playerpos.x + 20, Playerpos.y + 20, 0);
            }
            else if(isrightFlag && isupFlag == false && isdownFlag == false)//右
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 90));
                Attack.transform.position = new Vector3(Playerpos.x + 20, Playerpos.y, 0);
            }
            else if(isrightFlag && isdownFlag)//右下
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 225));
                Attack.transform.position = new Vector3(Playerpos.x + 20, Playerpos.y - 20, 0);
            }
            else if(isdownFlag && isrightFlag == false && isleftFlag == false)//下
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 180));
                Attack.transform.position = new Vector3(Playerpos.x, Playerpos.y - 20, 0);
            }
            else if(isleftFlag && isdownFlag)//左下
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 135));
                Attack.transform.position = new Vector3(Playerpos.x - 20, Playerpos.y - 20, 0);
            }
            else if(isleftFlag && isupFlag == false && isdownFlag == false)//左
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 270));
                Attack.transform.position = new Vector3(Playerpos.x - 20, Playerpos.y, 0);
            }
            span = 0;
        }
        span++;

    }
}
