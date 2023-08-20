using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{
    GameObject Player;//
    Vector3 Exppos;//
    Vector3 Playerpos;//
    Vector3 Number;  //
    Vector3 Move;    //
    double Getpos;   //
    double Distance; //
    bool isFlag;
    int count;
    // �Ԃ��������̉�
    public AudioClip se;
    // AudioClip�Đ��p
    AudioSource audiosource1;

    void Start()
    {
        // AudioSource�R���|�[�l���g�擾
        audiosource1 = GetComponent<AudioSource>();
        isFlag = false;
        Getpos = 20;
    }
    void FixedUpdate() 
    {
        count++;
    }
    void Update()
    {
        Exppos = this.transform.position;
        Player = GameObject.Find("player");
        Number.x = Exppos.x - Player.transform.position.x;//
        Number.y = Exppos.y - Player.transform.position.y;//
        Distance = Math.Sqrt(Number.x * Number.x + Number.y * Number.y);// 
        if (Distance < Getpos)
        {
            isFlag = true;
        }
        if (isFlag)
        {
            //�v���C���[�Ɍ������x�N�g���̍쐬
            Move = Player.transform.position - this.transform.position;
            Move = Move.normalized;
            //�������g���v���C���[�Ɍ����Ĉړ�
            this.transform.position += Move / 10;
        }    
        if(count > 1000)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(se, transform.position);
            Destroy(this.gameObject);
        }
    }
}
