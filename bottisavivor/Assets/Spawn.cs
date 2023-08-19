using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //プレハブ格納用
    public GameObject EnemyPrefab;
    public GameObject ToughEnemy;
    public GameObject FastEnemy;
    GameObject EnemySpawn;

    int count;
    int Max;//敵の数の上限
    int RandomNum;//敵の出現する場所を決める
    int RandomEnemy;//出現する敵を決める
    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count > 30)
        {
            RandomNum = Random.Range(0, 4);
            RandomEnemy = Random.Range(0, 20);

            float xleft = Random.Range(-252.0f, -202.0f);
            float yleft = Random.Range(-140.0f, 140.0f);
            Vector3 posleft = new Vector3(xleft, yleft, 0);

            float xright = Random.Range(208.0f, 228.0f);
            float yright = Random.Range(-140.0f, 140.0f);
            Vector3 posright = new Vector3(xright, yright, 0);

            float xtop = Random.Range(-250.0f, 290.0f);
            float ytop = Random.Range(113.0f, 150.0f);
            Vector3 postop = new Vector3(xtop, ytop, 0);

            float xunder = Random.Range(-278.0f, 258.0f);
            float yunder = Random.Range(-160.0f, -120.0f);
            Vector3 posunder = new Vector3(xunder, yunder, 0);

            if(RandomEnemy < 14)
            {
                EnemySpawn = EnemyPrefab;
            }
            else if(RandomEnemy > 14 && RandomEnemy < 18)
            {
                EnemySpawn = FastEnemy;
            }
            else
            {
                EnemySpawn = ToughEnemy;
            }

            //プレハブを指定位置に生成
            switch (RandomNum)
            {
                case 0:
                    Instantiate(EnemySpawn, posleft, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(EnemySpawn, posright, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(EnemySpawn, postop, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(EnemySpawn, posunder, Quaternion.identity);
                    break;
            }
            count = 0;
        }
    }
}

