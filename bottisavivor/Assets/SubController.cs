using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubController : MonoBehaviour
{
    Vector3 SubAttackPos;
    // Start is called before the first frame update
    void Start()
    {
        
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

    }
}
