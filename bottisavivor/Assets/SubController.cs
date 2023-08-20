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
        //自分自身の座標をとる
        SubAttackPos = this.transform.position;
        //マップ外に出たら消滅させる
        if (SubAttackPos.x < -200 || SubAttackPos.x > 200 || SubAttackPos.y < -100 || SubAttackPos.y > 100)
        {
            Destroy(this.gameObject);
        }

    }
}
