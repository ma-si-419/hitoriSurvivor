using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SubAttack : MonoBehaviour
{
    //����I���{�^���̒ǉ�
    public GameObject SelectButton1;
    public GameObject SelectButton2;
    //�C���[�W�̒ǉ�
    public GameObject image;
    public int span = 0;
    public GameObject SubAttack1;
    Vector3 Mousepos;//�}�E�X�̈ʒu
    Vector3 Playerpos;//�v���C���[�̈ʒu
    Vector3 Attackpos;//�U���̈ʒu
    
    float speed;

    void Start()
    {
        speed = 75.0f;  // �e�̑��x
    }
    void FixedUpdate()
    {
        if (SubSelectButton1.SubAttackCount == 1)
        {
            Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̍��W���Ƃ�
            Playerpos = this.transform.position;                           //�v���C���[�̍��W���Ƃ�
            Attackpos.x = Mousepos.x - Playerpos.x;//�w���W�̌v�Z
            Attackpos.y = Mousepos.y - Playerpos.y;//�x���W�̌v�Z
            if (span > 60)
            {
                GameObject clone = Instantiate(SubAttack1, transform.position, Quaternion.identity);

                // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // �����̐����iZ�����̏����Ɛ��K���j
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // �e�ɑ��x��^����
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

                // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // �����̐����iZ�����̏����Ɛ��K���j
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // �e�ɑ��x��^����
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

                // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // �����̐����iZ�����̏����Ɛ��K���j
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // �e�ɑ��x��^����
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

                // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // �����̐����iZ�����̏����Ɛ��K���j
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // �e�ɑ��x��^����
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

                // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // �����̐����iZ�����̏����Ɛ��K���j
                Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

                // �e�ɑ��x��^����
                clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
                span = 0;
            }
            span++;
        }
    }
    
}
