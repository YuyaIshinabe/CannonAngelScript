using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public PlayerController controller;
    public LifePanel lifePanel;
    public Text scoreLabel;
    int score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ライフの表示
        lifePanel.UpdateLife(controller.Life());
        //スコアの表示
        scoreLabel.text = "Score : " + score;


        //エスケープキーでゲーム終了
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //スコアの計算
    public int CalcScore(int point)
    {
        score = score + point;
        return score;
    }

    //スコアの値を渡す
    public int GetScore()
    {
        return score;
    }

}
