using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLevel : MonoBehaviour
{
    //武器選択ボタンの追加
    public GameObject SelectButton1;
    public GameObject SelectButton2;
    public GameObject SelectButton;
    public GameObject SelectButton3;
    //イメージの追加
    public GameObject image;
    public static int PlayerAttackLevel = 0;
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
        SelectButton3.SetActive(false);
        //ポーズを解除する
        Time.timeScale = 1;
        PlayerAttackLevel++;
    }


    void Update()
    {
        Debug.Log(PlayerAttackLevel);
        if (PlayerAttackLevel == 1)
        {
            
            EnemyController.damage = 2;
        }
        else if (PlayerAttackLevel == 2)
        {
            EnemyController.damage = 3;
            PlayerAttack.span = 40;
        }
        else if (PlayerAttackLevel == 3)
        {
            EnemyController.damage = 4;
        }
        else if (PlayerAttackLevel == 4)
        {
            EnemyController.damage = 5;
            PlayerAttack.span = 30;

        }
        else if (PlayerAttackLevel >= 5)
        {
            EnemyController.damage = 6;

        }
        else if(PlayerAttackLevel >= 6)
        {
            EnemyController.damage = 7;
            PlayerAttack.span = 20;
        }
    }
}
