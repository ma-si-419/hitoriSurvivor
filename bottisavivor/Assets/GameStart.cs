using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
   public void ClickStartButton()
    {
        PlayerLevel.PlayerLevelCount = 0;
        SubSelectButton1.SubAttackCount = 0;
        SubSelectButton2.SubAttackCount = 0;
        LevelUp.addText = 0;
        SceneManager.LoadScene("SampleScene");
    }
}
