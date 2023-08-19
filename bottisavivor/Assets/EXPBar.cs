using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EXPBar : MonoBehaviour
{
    int MaxXP = 30;
    //現在のXP
    int currentXP;
    //Sliderを入れる
    public Slider slider;
    //得られる経験値は1
    int EXP = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //ColliderオブジェクトのIsTriggerにチェックを入れること
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EXP"))
        {           
            //現在のXPと経験値を足す
            currentXP += EXP;
            //最大XPにおける現在のXPをSliderに反映。
            slider.value = currentXP;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (slider.value >= MaxXP)
        {
            currentXP = 0;
        }
    }
}