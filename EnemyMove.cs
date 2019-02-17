using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed;
    public Vector3 rot;

    // Update is called once per frame
    void Update()
    {
        //前進
        transform.position += transform.forward * Time.deltaTime * speed;
        //回転
        transform.Rotate(new Vector3(rot.x, rot.y, rot.z) * Time.deltaTime);
    }
}
