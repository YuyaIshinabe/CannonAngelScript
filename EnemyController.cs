using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject player;
    public GameController gameController;
    int point = 100;

	// Update is called once per frame
	void Update () {

        //プレイヤーが通り過ぎたら消す
        if (player.transform.position.z >= transform.position.z + 4)
        {
            Destroy(gameObject);
        }
    }

    //プレイヤーの弾に当たったらスコアを加算し、敵を消す
    //プレイヤーと敵の距離が遠いほど高得点
    void OnCollisionEnter(Collision collision)
    {
        point = point *  (int)(transform.position.z - player.transform.position.z);
        gameController.CalcScore(point);
        Destroy(gameObject);
    }
}
