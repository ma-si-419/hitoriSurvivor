using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject image;

    public void OnClick()
    {
        //�G�̓�����߂�
        EnemyController.EnemyMove = 100;
        ToughEnemyController.ToughEnemyMove = 150;
        FastEnemyController.FastEnemyMove = 1;
        BossController.BossStop = 1;
        //�C���[�W�̔�\��
        image.SetActive(false);

        //�|�[�Y����������
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
