using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideHeight : MonoBehaviour {


    Vector3 startPosition;
    public float amplitude;
    public float speed;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        //縦にスライドさせる
        float y = amplitude * Mathf.Sin(Time.time * speed);
        transform.localPosition = startPosition + new Vector3(0, y, 0);


    }
}
