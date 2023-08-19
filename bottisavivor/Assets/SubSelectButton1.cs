using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubSelectButton1 : MonoBehaviour
{
    SubAttack SubAttack;
    //武器選択ボタンの追加
    public GameObject SelectButton1;
    public GameObject SelectButton2;
    //イメージの追加
    public GameObject image;
    public GameObject SubAttack1;
    public static int SubAttackCount = 0;

    public void OnClick()
    {
        //敵の動きを戻す
        EnemyController.EnemyMove = 100;
        //イメージの非表示
        image.SetActive(false);
        //ボタンの非表示
        SelectButton1.SetActive(false);
        SelectButton2.SetActive(false);
        //ポーズを解除する
        Time.timeScale = 1;
        SubAttackCount++;
    }
}
