using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EXPBar : MonoBehaviour
{
    int MaxXP = 30;
    //���݂�XP
    int currentXP;
    //Slider������
    public Slider slider;
    //������o���l��1
    int EXP = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N�����邱��
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EXP"))
        {           
            //���݂�XP�ƌo���l�𑫂�
            currentXP += EXP;
            //�ő�XP�ɂ����錻�݂�XP��Slider�ɔ��f�B
            slider.value = currentXP;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (slider.value >= MaxXP)
        {
            currentXP = 0;
        }
    }
}