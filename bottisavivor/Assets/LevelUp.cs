using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUp : MonoBehaviour
{

    [SerializeField, Header("���݂̃��x��")]
    public TMP_Text LevelText;
    //Slider������
    public Slider slider;
    public int addText = 1;
    //�ő�XP
    int MaxXP = 30;
    //�C���[�W�̒ǉ�
    public GameObject image;
    //����I���{�^���̒ǉ�
    public GameObject SelectBottun1;
    public GameObject SelectBottun2;   
    //�G�̒ǉ�
    public GameObject MainEnemyPrefab;

    //���x���A�b�v���̃{�[�i�X
    public int BonusAttack = 1;
    //�T�u����J�E���g
    public static int count = 0;



    // Start is called before the first frame update
    void Start()
    {
        //�C���[�W�ƃ{�^�����\���ɂ���
        image.SetActive(false);
        SelectBottun1.SetActive(false);
        SelectBottun2.SetActive(false);
        //�X���C�_�[�̌��ݒl������
        slider = GameObject.Find("SliderXP").GetComponent<Slider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //slider.value = ���݂�XP
        if (slider.value >= MaxXP)
        {
            EnemyController.damage += BonusAttack;
            EnemyController.EnemyMove = 10000;
            //�ϐ�addText�𕶎���ɕϊ����Atext.text�ɑ�����\�����镶�͂�ύX
            LevelText.text = "Lv." + addText.ToString();
            //�ϐ�addText��1���Z
            addText = addText + 1;
            slider.value = 0;
            Time.timeScale = 0;
            image.SetActive(true);
            SelectBottun1.SetActive(true);
            SelectBottun2.SetActive(true);
            count++;
        }
    }
}