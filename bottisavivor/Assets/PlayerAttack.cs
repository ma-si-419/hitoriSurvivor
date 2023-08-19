using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public int span = 0;
    public GameObject AttackEffect;
    GameObject Attack;
    Vector3 Mousepos;//�}�E�X�̈ʒu
    Vector3 Playerpos;//�v���C���[�̈ʒu
    Vector3 Attackpos;//�U���̈ʒu
    int time;

    void FixedUpdate()
    {
        Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̍��W���Ƃ�
        Playerpos = this.transform.position;                           //�v���C���[�̍��W���Ƃ�
        Attackpos.x = Mousepos.x - Playerpos.x;//�w���W�̌v�Z
        Attackpos.y = Mousepos.y - Playerpos.y;//�x���W�̌v�Z
        if (span > 50)
        {
            
            Attack = Instantiate(AttackEffect) as GameObject;
            if (Attackpos.x < 25  && Attackpos.x > -25 && Attackpos.y > 0)//�^��ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 0));//0��]
            }
            if (Attackpos.x < 0 && Attackpos.y < 25 && Attackpos.y > -25)//���ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 90));//90�x��]
            }
            if (Attackpos.x < 25 && Attackpos.x > -25 && Attackpos.y < 0)//�^���ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 180));//180�x��]
            }
            if (Attackpos.x > 0 && Attackpos.y < 25 && Attackpos.y > -25)//�E�ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 270));//270�x��]
            }
            if (Attackpos.x < -25 && Attackpos.y > 25)//����ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 45));//45�x��]
            }
            if (Attackpos.x < -25 && Attackpos.y < -25)//�����ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 135));//135�x��]
            }
            if (Attackpos.x > 25 && Attackpos.y < -25)//�E���ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 225));//225�x��]
            }
            if (Attackpos.x > 25 && Attackpos.y > 25)//�E��ɍU������ꍇ
            {
                Attack.transform.Rotate(new Vector3(0, 0, 315));//315�x��]
            }
            Attack.transform.position = new Vector3 (Attackpos.x / 10 + Playerpos.x, Attackpos.y / 10 + Playerpos.y, 0);

            span = 0;
        }
        span++;

    }
}
