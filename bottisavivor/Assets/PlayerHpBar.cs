using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UIを使うときは忘れずに
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHpBar : MonoBehaviour
{
    int maxHp = 5;
    int currentHp;

    //hpbar無敵用の変数
    bool isHide = false;
    

    //Sliderを入れる
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        //Sliderを満タンにする
        slider.value = 5;
        //現在のHPと最大HPを同じにする
        currentHp = maxHp;
        //Debug.Log("Start currentHp : " + currentHp);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isHide)                    //↓キーとspaceを同時に押した場合
        {
            StartCoroutine("hpbardodge");
        }
    }

    IEnumerator hpbardodge()
    {
        isHide = true;
        Debug.Log("hpbardodge");
        yield return new WaitForSeconds(0.5f);
        isHide = false;
    }
    //ColliderオブジェクトのIsTriggerにチェック入れること。
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHide)
        {
            //PlayerDamageタグのオブジェクトに触れると発動
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //ダメージは1
                int damage = 0;
                //Debug.Log("damage : " + damage);

                //現在のHPからダメージを引く
                currentHp = currentHp - damage;
                //Debug.Log("After currentHp : " + currentHp);

                //最大HPにおける現在のHPをSliderに反映。
                //int同士の割り算は小数点以下は0になるので、
                //(float)をつけてfloatの変数として振舞わせる。
                slider.value = (float)currentHp / (float)maxHp; ;
                //Debug.Log("slider.value : " + slider.value);
            }
        }
        else if (!isHide)
        {
            //PlayerDamageタグのオブジェクトに触れると発動
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //ダメージは1
                int damage = 1;
                //Debug.Log("damage : " + damage);

                //現在のHPからダメージを引く
                currentHp = currentHp - damage;
                //Debug.Log("After currentHp : " + currentHp);

                //最大HPにおける現在のHPをSliderに反映。
                //int同士の割り算は小数点以下は0になるので、
                //(float)をつけてfloatの変数として振舞わせる。
                slider.value = (float)currentHp / (float)maxHp; ;
                //Debug.Log("slider.value : " + slider.value);
            }
        }
        if (currentHp == 0)
        {
            AttackLevel.PlayerAttackLevel = 0;
            SubSelectButton2.SubAttackCount = 0;
            SubSelectButton1.SubAttackCount = 0;
            PlayerLevel.PlayerLevelCount = 0;
            SceneManager.LoadScene("GameOverScene");
        }
    }
}



