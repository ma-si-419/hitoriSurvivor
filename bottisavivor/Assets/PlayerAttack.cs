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
        //Debug.Log("�ʂ��Ă�");

        //        Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̍��W���Ƃ�
        Playerpos = this.transform.position;                           //�v���C���[�̍��W���Ƃ�
        if (span > 50)
        {
            isButton = false;
            Attack = Instantiate(AttackEffect) as GameObject;
            if (Input.GetKey("w") || Input.GetKey("up"))//�^��ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));//0��]
                Addpos.y = 20;
                isup = true;
                isButton = true;
            }
            if (Input.GetKey("a") || Input.GetKey("left"))//���ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 90));//90�x��]
                Addpos.x = -20;
                isleft = true;
                isButton = true;
            }
            if (Input.GetKey("s") || Input.GetKey("down"))//�^���ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 180));//180�x��]
                Addpos.y = -20;
                isdown = true;
                isButton = true;
            }
            if (Input.GetKey("d") || Input.GetKey("right"))//�E�ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 270));//270�x��]
                Addpos.x = 20;
                isright = true;
                isButton = true;
            }
            if (isup && isleft)//����ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 315));//315�x��]
            }
            else if (isleft && isdown)//�����ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 225));//225�x��]
            }
            else if (isright && isdown)//�E���ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 135));//135�x��]
            }
            else if (isright && isup)//�E��ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 45));//45�x��]
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
