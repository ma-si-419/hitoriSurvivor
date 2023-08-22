using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public static int span = 50;
    int count;
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
    void Start()
    {
        isrightFlag = true;
        isupFlag = true;
        isleftFlag = false;
        isdownFlag = false;

        span = 50;
    }
    void FixedUpdate()
    {
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
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            isdownFlag = false;
            isupFlag = true;
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            isupFlag = false;
            isdownFlag = true;
        }
        Playerpos = this.transform.position;//�v���C���[�̍��W���Ƃ�
        if (span < count)
        {
            Attack = Instantiate(AttackEffect) as GameObject;

            if (isleftFlag && isupFlag)//����
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 45));
                Attack.transform.position = new Vector3(Playerpos.x - 10, Playerpos.y + 10, 0);
            }
            else if (isrightFlag && isupFlag)//�E��
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 315));
                Attack.transform.position = new Vector3(Playerpos.x + 10, Playerpos.y + 10, 0);
            }
            else if (isrightFlag && isdownFlag)//�E��
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 225));
                Attack.transform.position = new Vector3(Playerpos.x + 10, Playerpos.y - 10, 0);
            }
            else if (isleftFlag && isdownFlag)//����
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));
                Attack.transform.Rotate(new Vector3(0, 0, 135));
                Attack.transform.position = new Vector3(Playerpos.x - 15, Playerpos.y - 15, 0);
            }
            count = 0;
        }
        count++;

    }
}
