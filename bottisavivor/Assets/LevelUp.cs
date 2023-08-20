using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUp : MonoBehaviour
{

    [SerializeField, Header("現在のレベル")]
    public TMP_Text LevelText;
    //Sliderを入れる
    public Slider slider;
    public int addText = 1;
    //最大XP
    int MaxXP = 30;
    //イメージの追加
    public GameObject image;
    //武器選択ボタンの追加
    public GameObject SelectBottun1;
    public GameObject SelectBottun2;
    public GameObject PlayerLevelUP;
    //敵の追加
    public GameObject MainEnemyPrefab;

    //レベルアップ時のボーナス
    public int BonusAttack = 1;

    // Start is called before the first frame update
    void Start()
    {
        //イメージとボタンを非表示にする
        image.SetActive(false);
        SelectBottun1.SetActive(false);
        SelectBottun2.SetActive(false);
        PlayerLevelUP.SetActive(false);
        //スライダーの現在値を入れる
        slider = GameObject.Find("SliderXP").GetComponent<Slider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //slider.value = 現在のXP
        if (slider.value >= MaxXP)
        {
            EnemyController.damage += BonusAttack;
            EnemyController.EnemyMove = 10000;
            //変数addTextを文字列に変換し、text.textに代入＝表示する文章を変更
            LevelText.text = "Lv." + addText.ToString();
            //変数addTextを1加算
            addText = addText + 1;
            slider.value = 0;
            Time.timeScale = 0;
            image.SetActive(true);
            if (SubSelectButton1.SubAttackCount < 5)
            {
                SelectBottun1.SetActive(true);
            }
            if (SubSelectButton2.SubAttackCount < 5)
            {
                SelectBottun2.SetActive(true);
            }
            if (PlayerLevel.PlayerLevelCount < 5)
            {
                PlayerLevelUP.SetActive(true);
            }            
        }        
    }
}