using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {
    public Text HighScoreLabel;

    // Use this for initialization
    void Start()
    {
        //ハイスコアの表示
        HighScoreLabel.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        //エンターキーでゲームスタート
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Main");
        }

        //エスケープキーでゲーム終了
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
