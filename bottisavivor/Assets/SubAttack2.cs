using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttack2 : MonoBehaviour
{
    //武器選択ボタンの追加
    public GameObject SelectButton1;
    public GameObject SelectButton2;
    //イメージの追加
    public GameObject image;
    public int span = 0;
    public GameObject SubAttack;
    public GameObject SubAttackBreak;

    void FixedUpdate()
    {
        if (SubSelectButton2.SubAttackCount == 0)
        {
            SubAttack.SetActive(false);
            SubAttackBreak.SetActive(false);
        }
        else if (SubSelectButton2.SubAttackCount == 1)
        {
            if (span < 45)
            {
                SubAttack.SetActive(true);
                SubAttackBreak.SetActive(false);
            }
            else if (span < 225 && span > 45)
            {
                SubAttack.SetActive(false);
                SubAttackBreak.SetActive(true);
            }
            else if (span > 225)
            {
                span = 0;
            }
            span++;
        }
        else if (SubSelectButton2.SubAttackCount == 2)
        {
            if (span < 45)
            {
                SubAttack.SetActive(true);
                SubAttackBreak.SetActive(false);
            }
            else if (span < 180 && span > 45)
            {
                SubAttack.SetActive(false);
                SubAttackBreak.SetActive(true);
            }
            else if (span > 180)
            {
                span = 0;
            }
            span++;
        }
        else if (SubSelectButton2.SubAttackCount == 3)
        {
            if (span < 45)
            {
                SubAttack.SetActive(true);
                SubAttackBreak.SetActive(false);
            }
            else if (span < 135 && span > 45)
            {
                SubAttack.SetActive(false);
                SubAttackBreak.SetActive(true);
            }
            else if (span > 135)
            {
                span = 0;
            }
            span++;
        }
        else if (SubSelectButton2.SubAttackCount == 4)
        {
            if (span < 45)
            {
                SubAttack.SetActive(true);
                SubAttackBreak.SetActive(false);
            }
            else if (span < 90 && span > 45)
            {
                SubAttack.SetActive(false);
                SubAttackBreak.SetActive(true);
            }
            else if (span > 90)
            {
                span = 0;
            }
            span++;
        }
        else if (SubSelectButton2.SubAttackCount >= 5)
        {
            SubAttack.SetActive(true);
            SubAttackBreak.SetActive(false);
        }
    }
}
