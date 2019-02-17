using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToTitle : MonoBehaviour {
    public Text ScoreLabel;

    // Use this for initialization
    void Start()
    {
        //スコアの表示
        ScoreLabel.text = "Score : " + PlayerPrefs.GetInt("Score");
    }    
	// Update is called once per frame
	void Update () {

        //エンターキーが押されたらタイトルへ
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Title");
        }

        //エスケープキーでゲーム終了
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
