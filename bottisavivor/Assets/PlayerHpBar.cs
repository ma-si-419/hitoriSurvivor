using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UIを使うときは忘れずに
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHpBar : MonoBehaviour
{
    int maxHp = 3;
    int currentHp;

    //hpbar無敵用の変数
    bool isHide = false;
    int cooldown = 2500;

    //Sliderを入れる
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        //Sliderを満タンにする
        slider.value = 3;
        //現在のHPと最大HPを同じにする
        currentHp = maxHp;
        //Debug.Log("Start currentHp : " + currentHp);
    }

    void Update()
    {

        if (cooldown > 2500)
        {
            if (Input.GetKey("w") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)                    //wキーとspaceを同時に押した場合
            {
                StartCoroutine("hpbardodge");
                cooldown = 0;
            }
            if (Input.GetKey("a") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)                    //aキーとspaceを同時に押した場合
            {
                StartCoroutine("hpbardodge");
                cooldown = 0;
            }
            if (Input.GetKey("s") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)                    //sキーとspaceを同時に押した場合
            {
                StartCoroutine("hpbardodge");
                cooldown = 0;
            }
            if (Input.GetKey("d") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)                     //dキーとspaceを同時に押した場合
            {
                StartCoroutine("hpbardodge");
                cooldown = 0;
            }
            if (Input.GetKey("right") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)                    //→キーとspaceを同時に押した場合
            {
                StartCoroutine("hpbardodge");
                cooldown = 0;
            }
            if (Input.GetKey("left") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)                   //←キーとspaceを同時に押した場合
            {
                StartCoroutine("hpbardodge");
                cooldown = 0;
            }
            if (Input.GetKey("up") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)                   //↑キーとspaceを同時に押した場合
            {
                StartCoroutine("hpbardodge");
                cooldown = 0;
            }
            if (Input.GetKey("down") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)                    //↓キーとspaceを同時に押した場合
            {
                StartCoroutine("hpbardodge");
                cooldown = 0;
            }
        }
        IEnumerator hpbardodge()
        {
            isHide = true;

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
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}



