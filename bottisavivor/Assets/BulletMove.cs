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
        //�v���C���[�̃I�u�W�F�N�g���擾
        Enemy = GameObject.Find("player");


        Boss = new Vector3();
        //�{�X�̍��W�Ǝ����̍��W���Ƃ�A�{�X�Ǝ����̍��W�𗣂�Ă����悤�ɏ�������
        Boss = Enemy.transform.position - this.transform.position;
        Boss = Boss.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        Enemypos = this.transform.position;

        //�v���C���[�Ɍ������Ĕ��ł���
        this.transform.position += Boss / 10;

        //�G�̍��W���}�b�v�O�ɏo������ł�����
        if (Enemypos.x > 200 || Enemypos.x < -200 || Enemypos.y > 100 || Enemypos.y < -100)
        {
            Destroy(this.gameObject);
        }
        //�{�X�Ɗ��S�ɓ����ʒu�ɏo���ꍇ���ł�����
        if(Enemypos == Boss)
        {
            Destroy(this.gameObject);
        }
        //�e���~�܂��Ă��܂����ꍇ����
        if(count == 2000)
        {
            Destroy(this.gameObject);
        }
    }
}