using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    public GameObject enemyBulletPrefab;
    public GameObject player;
    public Vector3 Rotation;
    public float bulletSpeed;
    private float timeCount = 0;

    void FixedUpdate()
    {

        timeCount += 1;
        //発射間隔
        if (timeCount % 50 == 0)
        {

            if (transform.position.z - player.transform.position.z <= 50)
            {
                // 敵の弾を生成する
                GameObject enemyMissile = Instantiate(
                    enemyBulletPrefab,
                    transform.position,
                    Quaternion.Euler(Rotation)
                    ) as GameObject;
               

                Rigidbody enemyBulletRb = enemyMissile.GetComponent<Rigidbody>();

                // 弾を飛ばす方向を決める
                enemyBulletRb.AddForce(transform.forward * bulletSpeed);



                // １２秒後に敵のミサイルを削除
                Destroy(enemyMissile, 12.0f);
            }

        }
    }


}
