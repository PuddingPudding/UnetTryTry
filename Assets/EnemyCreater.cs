using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class EnemyCreater  : NetworkBehaviour
{
    //敵人物件
    public GameObject enemy;
    //倒數時間
    public float time = 0.5f;
    //剩餘時間
    private float countdown;
    void Start()
    {
        countdown = time;
    }

    void Update()
    {
        if (!isServer)
        {
            //若不是Server則跳出
            return;
        }
        //每經過一段時間建立一個新敵人
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            countdown = time;
            createNewEnemy();
        }
    }
    void createNewEnemy()
    {
        //生成物件 隨機出現在X Y -5~5的地方
        GameObject newEnemy = Instantiate(enemy, new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.identity);
        //透過NetworkServer 卵生到Client端
        NetworkServer.Spawn(newEnemy);
    }
}
