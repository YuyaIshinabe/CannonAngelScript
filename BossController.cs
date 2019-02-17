using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour {
    public GameObject effectPrefab;
    public GameObject option;
    public GameObject player;
    public GameController gameController;
    public float count = 0;
    int point = 300000;
    bool one;
    AudioSource explosionSound;

    // Use this for initialization
    void Start () {
        one = true;
        explosionSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //カウントが35になったらクリア
		if(count >= 35 && one)
        {
            one = false;
            Explosion();
        }



        
	}

    //プレイヤーの弾に当たったらカウントに1を加算
    void OnCollisionEnter(Collision collision)
    {
        count++;
    }

    public void Explosion()
    {
        Invoke("GameClear", 3f);
        //爆発エフェクト
        Instantiate(
            effectPrefab,
            new Vector3 (transform.position.x, transform.position.y + 2, transform.position.z - 6),
            Quaternion.identity
            );
        //爆発音の再生
        explosionSound.Play();

        //スコアに加算
        //早く倒すほど高得点
        point = (int)point / ((int)Time.time / 2);
        gameController.CalcScore(point);
    }

    public void GameClear()
    {
        //スコア保存
        PlayerPrefs.SetInt("Score", gameController.GetScore());

        //ハイスコアの保存
        if (PlayerPrefs.GetInt("HighScore") < gameController.GetScore())
        {
            PlayerPrefs.SetInt("HighScore", gameController.GetScore());
        }
        SceneManager.LoadScene("GameClear");
        Destroy(gameObject);
    }
}
