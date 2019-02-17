using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStage : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.z >= 20)
        {
            Destroy(gameObject);
        }
	}
}
