using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcontroll : MonoBehaviour
{
    private Animator anim = null;//アニメーターに接続する
    public float playerspeed;//プレイヤーの移動速度
    public float speedx;//縦方向への移動
    public float speedy;//横方向への移動
    bool isleftFlag = false;//左右反転させるための変数
    Vector3 Playerpos;//プレイヤーのポジション
    //無敵時間用変数
    int cooldown = 500;
    int hitPoint;   　//キャラクターのヒットポイント
    bool isHide;

    bool isRun = false;

    ////回避行動、無敵時間用の変数
    //int cooldown = 2500;
    //bool isHide = false;

    void Start()
    {
        anim = GetComponent<Animator>();//アニメーションの変数
    }


    //キーを押すと、プレイヤーが移動する
    void Update()
    {
        Playerpos = this.transform.position;//プレイヤーのポジションを獲得する

        speedx = 0;//何も入力していない場合は止まる
        speedy = 0;//何も入力していない場合は止まる


        isRun = false;//何も入力していない場合は止まるアニメーション

        if (Input.GetKey("d"))//dキーを入力した場合
        {
            speedx = playerspeed;//右方向に進む
            isleftFlag = false;//向きを右にする
            isRun = true;//走るアニメーションを動かす
        }
        if (Input.GetKey("a"))//aキーを入力した場合
        {
            speedx = -playerspeed;//左方向に進む
            isleftFlag = true;//左向きにする
            isRun = true;//走るアニメーションを動かす
        }
        if (Input.GetKey("w"))//wキーを入力した場合
        {
            speedy = playerspeed;//上方向に進む
            isRun = true;//走るアニメーションを動かす
        }
        if (Input.GetKey("s"))//sキーを入力した場合
        {
            speedy = -playerspeed;//下方向に進む
            isRun = true;//走るアニメーションを動かす
        }
        if (Input.GetKey("right"))//→キーを入力した場合
        {
            speedx = playerspeed;//右方向に進む
            isleftFlag = false;//向きを右にする
            isRun = true;//走るアニメーションを動かす
        }
        if (Input.GetKey("left"))//←キーを入力した場合
        {
            speedx = -playerspeed;//左方向に進む
            isleftFlag = true;//向きを左にする
            isRun = true;//走るアニメーションを動かす
        }
        if (Input.GetKey("up"))//↑キーを入力した場合
        {
            speedy = playerspeed;//上方向に進む
            isRun = true;//走るアニメーションを動かす
        }
        if (Input.GetKey("down"))//↓キーを入力した場合
        {
            speedy = -playerspeed;//下方向に進む
            isRun = true;//走るアニメーションを動かす
        }
        if (Playerpos.x < -200)//画面外に出そうになったら止まる
        {
            if (speedx < 0) speedx = 0;
        }
        else if (Playerpos.x > 200)
        {
            if (speedx > 0) speedx = 0;
        }
        if(Playerpos.y < -100)
        {
            if (speedy < 0) speedy = 0;
        }
        else if(Playerpos.y > 100)
        {
            if(speedy > 0) speedy = 0;
        }

        anim.SetBool("Run", isRun);//走るアニメーションを動かす

        if (cooldown > 500)
        {

            //ここから無敵時間と回避時間の追加

            if (Input.GetKey("d") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)//spaceとdキーを入力した場合
            {
                speedx = playerspeed;//右方向に進む
                isleftFlag = false;//向きを右にする

                StartCoroutine("Playerdodge");

                cooldown = 0;//クールダウンタイムをリセットセットする
            }
            if (Input.GetKey("a") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)//spaceとaキーを入力した場合
            {
                speedx = -playerspeed;//左方向に進む
                isleftFlag = true;//左向きにする

                StartCoroutine("Playerdodge");

                cooldown = 0;
            }
            if (Input.GetKey("w") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)//spaceとwキーを入力した場合
            {
                speedy = playerspeed;//上方向に進む

                StartCoroutine("Playerdodge");

                cooldown = 0;
            }
            if (Input.GetKey("s") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)//spaceとsキーを入力した場合
            {
                speedy = -playerspeed;//下方向に進む

                StartCoroutine("Playerdodge");

                cooldown = 0;
            }
            if (Input.GetKey("right") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)//spaceと→キーを入力した場合
            {
                speedx = playerspeed;//右方向に進む
                isleftFlag = false;//向きを右にする

                StartCoroutine("Playerdodge");

                cooldown = 0;
            }
            if (Input.GetKey("left") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)//spaceと←キーを入力した場合
            {
                speedx = -playerspeed;//左方向に進む
                isleftFlag = true;//向きを左にする

                StartCoroutine("Playerdodge");

                cooldown = 0;
            }
            if (Input.GetKey("up") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)//spaceと↑キーを入力した場合
            {
                speedy = playerspeed;//上方向に進む

                StartCoroutine("Playerdodge");

                cooldown = 0;
            }
            if (Input.GetKey("down") &&
                Input.GetKeyDown(KeyCode.Space) &&
                !isHide)//spaceと↓キーを入力した場合
                
            {
                speedy = -playerspeed;//下方向に進む

                StartCoroutine("Playerdodge");

                cooldown = 0;
            }

        }
        cooldown++;
    }

    IEnumerator Playerdodge()
    {
        isHide = true;
        Debug.Log("playerdodge");
        yield return new WaitForSeconds(0.2f);
        isHide = false;
    }


    void FixedUpdate()
    {
        //移動する
        if (!isHide)
        {
            this.transform.Translate(speedx / 30, speedy / 30, 0);
        }
        if (isHide)
        {
            this.transform.Translate(speedx / 10, speedy / 10, 0);
        }

        //左右の向きを変える
        this.GetComponent<SpriteRenderer>().flipX = isleftFlag;
    }
}