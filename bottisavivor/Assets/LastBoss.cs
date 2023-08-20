using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastBoss : MonoBehaviour
{
    int BossHp = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHp == 0) 
        {
            SceneManager.LoadScene("GameClearScene");
        }
    }
}
