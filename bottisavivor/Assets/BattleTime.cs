using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

/// <summary>
/// �Q�[�����ɐ������Ԃ��u���F�b�v�ŕ\������N���X
/// </summary>
public class BattleTime : MonoBehaviour
{

    [SerializeField, Header("�������Ԃ̐ݒ�l")]
    public int battleTime;
    [SerializeField, Header("�������Ԃ̕\��")]
    public TMP_Text battleTimeText;
    [SerializeField] GameObject text;     //�e�L�X�g��\��������ۂɎg�p����ϐ�
    [SerializeField] GameObject BossText; //�{�X���o�ꂷ��ۂɎg�p����e�L�X�g

    private int currentTime;              // ���݂̎c�莞�ԁi�s�v�ȏꍇ�͐錾���Ȃ��j
    private float timer;                  // ���Ԍv���p
    public GameObject Boss1;              //��l�ڂ̃{�X
    public GameObject Boss2;              //��l�ڂ̃{�X
    public GameObject EnemyPrefab;        //�ʏ�̎G���G
    public GameObject FastEnemyPrefab;    //���̑����G���G
    Vector3 BossPlace;                    //�{�X�̏o���ʒu�̐ݒ�
    public GameObject BossExplosion;                //�{�X�̏o�����o
    Vector3 EnemyPlace;                   //�G�̏o���ʒu�̐ݒ�
    int count;                            //�o���^�C�~���O�̒���
    GameObject BossEntry;
    int EventNum;//�C�x���g�p�̕ϐ�
    int RandomPlace;//�C�x���g�Ŏg�p����ϐ�
    bool isEventFlag;
    int EventTime; //�C�x���g�̎��Ԃ��v������ϐ�
    bool isBossFlag;
    void Start()
    {

        BossPlace = new Vector3(0.0f, 46.0f, 0.0f);//�{�X�̏o���ʒu�̐ݒ�
        // currentTime�𗘗p����ꍇ�ɂ͂����ő������B�ȉ��A�K�v�ɉ�����battleTime��currentTime�ɏ���������
        currentTime = battleTime;
    }
    private void FixedUpdate()
    {

        if (battleTime % 120 == 0 && isEventFlag == false && battleTime > 1)
        {
            EventNum += 1;
            isEventFlag = true;
        }
        if (isEventFlag == true)
        {
            EventTime += 1;
        }
    }
    void Update()
    {
        // timer�𗘗p���Čo�ߎ��Ԃ��v��
        timer += Time.deltaTime;

        switch (EventNum)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    if (isEventFlag)
                    {

                        count++;
                        text.SetActive(true);
                        if (count % 60 == 0)
                        {
                            RandomPlace = Random.Range(0, 4);
                            switch (RandomPlace)
                            {
                                case 0:
                                    EnemyPlace = new Vector3(Random.Range(-200, -200), Random.Range(-150, 150), 0);//����������G���o������
                                    Instantiate(FastEnemyPrefab, EnemyPlace, Quaternion.identity);
                                    break;
                                case 1:
                                    EnemyPlace = new Vector3(Random.Range(200, 200), Random.Range(-150, 150), 0);//�E��������G���o������
                                    Instantiate(FastEnemyPrefab, EnemyPlace, Quaternion.identity);
                                    break;
                                case 2:
                                    EnemyPlace = new Vector3(Random.Range(-250, 250), Random.Range(150, 200), 0);//���������G���o������
                                    Instantiate(FastEnemyPrefab, EnemyPlace, Quaternion.identity);
                                    break;
                                case 3:
                                    EnemyPlace = new Vector3(Random.Range(-250, 250), Random.Range(-150, -200), 0);
                                    Instantiate(FastEnemyPrefab, EnemyPlace, Quaternion.identity);
                                    break;
                            }
                        }
                        if (EventTime > 500)
                        {
                            count = 0;
                            EventTime = 0;
                            isEventFlag = false;
                        }
                    }
                    break;
                }
            case 2:
                if (isEventFlag)
                {

                    count++;
                    text.SetActive(true);
                    if (count % 3 == 0)
                    {
                        RandomPlace = Random.Range(0, 4);
                    }
                    switch (RandomPlace)
                    {
                        case 0:
                            EnemyPlace = new Vector3(-200, Random.Range(-150, 150), 0);//����������G���o������
                            Instantiate(EnemyPrefab, EnemyPlace, Quaternion.identity);
                            break;
                        case 1:
                            EnemyPlace = new Vector3(200, Random.Range(-150, 150), 0);//�E��������G���o������
                            Instantiate(EnemyPrefab, EnemyPlace, Quaternion.identity);
                            break;
                        case 2:
                            EnemyPlace = new Vector3(Random.Range(-200, 200), 100, 0);//���������G���o������
                            Instantiate(EnemyPrefab, EnemyPlace, Quaternion.identity);
                            break;
                        case 3:
                            EnemyPlace = new Vector3(Random.Range(-200, 200), -100, 0);
                            Instantiate(EnemyPrefab, EnemyPlace, Quaternion.identity);
                            break;
                    }
                    if (count > 200)
                    {
                        count = 0;
                        EventNum = 0;
                        EventTime = 0;
                        isEventFlag = false;
                    }
                }
                break;
        }

        if(battleTime == 10)
        {
            BossText.SetActive(true);
            isBossFlag = false;
        }
        if (battleTime == 0 && isBossFlag == false)
        {
            Instantiate(BossExplosion,new Vector3(0.0f, 46.0f, 0.0f), Quaternion.identity);
            BossEntry = Instantiate(Boss1) as GameObject;
            BossEntry.transform.position = new Vector3(0.0f, 46.0f, 0.0f);
            isBossFlag = true;
        }
        // 1�b�o�߂��Ƃ�timer��0�ɖ߂��AbattleTime(currentTime)�����Z����
        if (timer >= 1)
        {
            timer = 0;
            if (battleTime > 0)
            {
                battleTime--;  // ���邢�́AcurrentTime--;
                               // ���ԕ\�����X�V���郁�\�b�h���Ăяo��
                DisplayBattleTime(battleTime);   // ���邢�́ADisplayBattleTime(currentTime);
            }

        }

    }

    /// <summary>
    /// �������Ԃ��X�V����[��:�b]�ŕ\������
    /// </summary>
    private void DisplayBattleTime(int limitTime)
    {
        // �����Ŏ󂯎�����l��[��:�b]�ɕϊ����ĕ\������
        // ToString("00")�Ń[���v���[�X�t�H���_�[���āA�P���̂Ƃ��͓���0������
        battleTimeText.text = ((int)(limitTime / 60)).ToString("00") + ":" + ((int)limitTime % 60).ToString("00");
    }
}
