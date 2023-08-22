using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject image;

    public void OnClick()
    {
        //敵の動きを戻す
        EnemyController.EnemyMove = 100;
        ToughEnemyController.ToughEnemyMove = 150;
        FastEnemyController.FastEnemyMove = 1;
        BossController.BossStop = 1;
        //イメージの非表示
        image.SetActive(false);

        //ポーズを解除する
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
