using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

/// <summary>
/// ゲーム内に制限時間を「分：秒」で表示するクラス
/// </summary>
public class BattleTime : MonoBehaviour
{

    [SerializeField, Header("制限時間の設定値")]
    public int battleTime;
    [SerializeField, Header("制限時間の表示")]
    public TMP_Text battleTimeText;
    [SerializeField] GameObject text;     //テキストを表示させる際に使用する変数
    [SerializeField] GameObject BossText; //ボスが登場する際に使用するテキスト

    private int currentTime;              // 現在の残り時間（不要な場合は宣言しない）
    private float timer;                  // 時間計測用
    public GameObject Boss1;              //一人目のボス
    public GameObject Boss2;              //二人目のボス
    public GameObject EnemyPrefab;        //通常の雑魚敵
    public GameObject FastEnemyPrefab;    //足の速い雑魚敵
    Vector3 BossPlace;                    //ボスの出現位置の設定
    public GameObject BossExplosion;                //ボスの出現演出
    Vector3 EnemyPlace;                   //敵の出現位置の設定
    int count;                            //出現タイミングの調整
    GameObject BossEntry;
    int EventNum;//イベント用の変数
    int RandomPlace;//イベントで使用する変数
    bool isEventFlag;
    int EventTime; //イベントの時間を計測する変数
    bool isBossFlag;
    void Start()
    {

        BossPlace = new Vector3(0.0f, 46.0f, 0.0f);//ボスの出現位置の設定
        // currentTimeを利用する場合にはここで代入する。以下、必要に応じてbattleTimeをcurrentTimeに書き換える
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
        // timerを利用して経過時間を計測
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
                                    EnemyPlace = new Vector3(Random.Range(-200, -200), Random.Range(-150, 150), 0);//左方向から敵が出現する
                                    Instantiate(FastEnemyPrefab, EnemyPlace, Quaternion.identity);
                                    break;
                                case 1:
                                    EnemyPlace = new Vector3(Random.Range(200, 200), Random.Range(-150, 150), 0);//右方向から敵が出現する
                                    Instantiate(FastEnemyPrefab, EnemyPlace, Quaternion.identity);
                                    break;
                                case 2:
                                    EnemyPlace = new Vector3(Random.Range(-250, 250), Random.Range(150, 200), 0);//上方向から敵が出現する
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
                            EnemyPlace = new Vector3(-200, Random.Range(-150, 150), 0);//左方向から敵が出現する
                            Instantiate(EnemyPrefab, EnemyPlace, Quaternion.identity);
                            break;
                        case 1:
                            EnemyPlace = new Vector3(200, Random.Range(-150, 150), 0);//右方向から敵が出現する
                            Instantiate(EnemyPrefab, EnemyPlace, Quaternion.identity);
                            break;
                        case 2:
                            EnemyPlace = new Vector3(Random.Range(-200, 200), 100, 0);//上方向から敵が出現する
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
        // 1秒経過ごとにtimerを0に戻し、battleTime(currentTime)を減算する
        if (timer >= 1)
        {
            timer = 0;
            if (battleTime > 0)
            {
                battleTime--;  // あるいは、currentTime--;
                               // 時間表示を更新するメソッドを呼び出す
                DisplayBattleTime(battleTime);   // あるいは、DisplayBattleTime(currentTime);
            }

        }

    }

    /// <summary>
    /// 制限時間を更新して[分:秒]で表示する
    /// </summary>
    private void DisplayBattleTime(int limitTime)
    {
        // 引数で受け取った値を[分:秒]に変換して表示する
        // ToString("00")でゼロプレースフォルダーして、１桁のときは頭に0をつける
        battleTimeText.text = ((int)(limitTime / 60)).ToString("00") + ":" + ((int)limitTime % 60).ToString("00");
    }
}
