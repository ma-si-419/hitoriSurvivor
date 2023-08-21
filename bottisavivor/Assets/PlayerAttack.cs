using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public int span = 0;
    public GameObject AttackEffect;
    GameObject Attack;
    Vector3 Addpos;//�}�E�X�̈ʒu
    Vector3 Playerpos;//�v���C���[�̈ʒu
    Vector3 Attackpos;//�U���̈ʒu
    Vector3 AttackLog;//�ۑ�����U���̈ʒu
    int time;
    bool isleftFlag;
    bool isupFlag;
    bool isrightFlag;
    bool isdownFlag;
    void FixedUpdate()
    {
        Playerpos = this.transform.position;                           //�v���C���[�̍��W���Ƃ�
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
            if (isleftFlag && isupFlag)//����
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 45));
                Attack.transform.position = new Vector3(Playerpos.x - 20, Playerpos.y + 20, 0);
            }
            else if (isleftFlag == false && isrightFlag == false &&isupFlag)//��
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.position = new Vector3(Playerpos.x, Playerpos.y + 20, 0);
            }
            else if(isrightFlag && isupFlag)//�E��
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 315));
                Attack.transform.position = new Vector3(Playerpos.x + 20, Playerpos.y + 20, 0);
            }
            else if(isrightFlag && isupFlag == false && isdownFlag == false)//�E
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 90));
                Attack.transform.position = new Vector3(Playerpos.x + 20, Playerpos.y, 0);
            }
            else if(isrightFlag && isdownFlag)//�E��
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 225));
                Attack.transform.position = new Vector3(Playerpos.x + 20, Playerpos.y - 20, 0);
            }
            else if(isdownFlag && isrightFlag == false && isleftFlag == false)//��
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 180));
                Attack.transform.position = new Vector3(Playerpos.x, Playerpos.y - 20, 0);
            }
            else if(isleftFlag && isdownFlag)//����
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 135));
                Attack.transform.position = new Vector3(Playerpos.x - 20, Playerpos.y - 20, 0);
            }
            else if(isleftFlag && isupFlag == false && isdownFlag == false)//��
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
