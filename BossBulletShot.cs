using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletShot : MonoBehaviour {

    public GameObject bossBulletPrefab;
    public GameObject player;
    public Vector3 Rotation;
    public float bulletSpeed;
    private float timeCount = 0;
    GameObject bullet;
    public int[] numbers = {5, 10, 0, -5, -10};

    void FixedUpdate()
    {

        timeCount += 1;

        //発射間隔
        if (timeCount % 30 == 0)
        {

            if (player.transform.position.z >= 190)
            {
                // ボスの弾を生成する
                bullet = Instantiate(
                    bossBulletPrefab,
                    transform.position,
                    Quaternion.Euler(Rotation)
                    ) as GameObject;


                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

                // 弾を飛ばす
                int x = numbers[Random.Range(0, 4)];
                int y = numbers[Random.Range(0, 4)];
                bulletRb.AddForce(x, y, transform.forward.z * bulletSpeed);



                // 12秒後に敵のミサイルを削除する。
                Destroy(bullet, 12.0f);
            }

        }
    }


}
