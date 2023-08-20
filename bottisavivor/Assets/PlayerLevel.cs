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
            
        }
        else if (SubSelectButton2.SubAttackCount == 2)
        {
           
        }
        else if (SubSelectButton2.SubAttackCount == 3)
        {
            
        }
        else if (SubSelectButton2.SubAttackCount == 4)
        {
            
        }
        else if (SubSelectButton2.SubAttackCount >= 5)
        {
            
        }
    }
}
