using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    public GameObject effectPrefab;
    public Vector3 effectRotation;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        Instantiate(
    effectPrefab,
    new Vector3(x: transform.position.x, y: transform.position.y, z: transform.position.z),
    Quaternion.Euler(effectRotation)
    );
        Destroy(gameObject);
    }
}
