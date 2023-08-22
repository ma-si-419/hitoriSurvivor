using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubController : MonoBehaviour
{
    Vector3 SubAttackPos;
    int SubAttackLevel;
    bool isFlag;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        isFlag = false;
    }
    void FixedUpdate()
    {
        count++;
    }
    // Update is called once per frame
    void Update()
    {
        //�������g�̍��W���Ƃ�
        SubAttackPos = this.transform.position;
        //�}�b�v�O�ɏo������ł�����
        if (SubAttackPos.x < -200 || SubAttackPos.x > 200 || SubAttackPos.y < -100 || SubAttackPos.y > 100)
        {
            Destroy(this.gameObject);
        }
        SubAttackLevel = SubSelectButton1.SubAttackCount;//�T�u�U���̃��x�����Ƃ�
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (SubAttackLevel <= 5)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                isFlag = true;
                if (count > 10)
                {
                    Destroy(this.gameObject);
                    isFlag = false;
                }
            }
        }
    }

}
