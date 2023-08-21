using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    //武器選択ボタンの追加
    public GameObject SelectButton1;
    public GameObject SelectButton2;
    public GameObject SelectButton;
    //イメージの追加
    public GameObject image;
    public static int PlayerLevelCount = 0;
    public void OnClick()
    {
        //敵の動きを戻す
        EnemyController.EnemyMove = 100;
        ToughEnemyController.ToughEnemyMove = 150;
        FastEnemyController.FastEnemyMove = 1;
        BossController.BossStop = 1;
        //イメージの非表示
        image.SetActive(false);
        //ボタンの非表示
        SelectButton1.SetActive(false);
        SelectButton2.SetActive(false);
        SelectButton.SetActive(false);
        //ポーズを解除する
        Time.timeScale = 1;
        PlayerLevelCount++;
    }

    
    void FixedUpdate()
    {        
        if (SubSelectButton2.SubAttackCount == 1)
        {
            charcontroll.Move = 15;
        }
        else if (SubSelectButton2.SubAttackCount == 2)
        {
            charcontroll.Move = 20;
        }
        else if (SubSelectButton2.SubAttackCount == 3)
        {
            charcontroll.Move = 25;
        }
        else if (SubSelectButton2.SubAttackCount == 4)
        {
            charcontroll.Move = 30;
        }
        else if (SubSelectButton2.SubAttackCount >= 5)
        {
            charcontroll.Move = 35;
        }
    }
}
