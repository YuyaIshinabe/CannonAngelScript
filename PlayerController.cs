using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {


    const int defaultLife = 5;


    CharacterController controller;
    bool isDead;
    Vector3 moveDirection = Vector3.zero;
    public float speedX;
    public float speedY;
    public float speedZ;
    public float accelerationZ;
    public float maxHeight;
    public float minHeight;
    public float maxRight;
    public float maxLeft;
    public GameController gameController;
    public GameObject cannonObject;
    Animator animator;
    bool One;
    bool Uno;
    int life = defaultLife;



    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        One = true;
        Uno = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        //空中時
        if (transform.position.z > 11.9)
        {
            //当たり判定を変える
            controller.center = new Vector3(0, 11, 5);
            controller.radius = 4;
            controller.height = 1;
            //上下に移動できるように
            UpDown();
        }

        Forward();

        RightLeft();



        //前進を止める
        if (transform.position.z >= 195f)
        {
            speedZ = 0;
        }


        //モーションを変える
        if (transform.position.z > 11.9 && Uno)
        {
            animator.SetTrigger("Fly");
            cannonObject.transform.localPosition = new Vector3(0, 7.0f, -1.8f);
            Uno = false;
        }

        //ライフが0になったらゲームオーバー
        if(life <= 0)
        {
            ToGameOver();
        }


    }

    public int Life()
    {
        return life;
    }

    //上下の移動
    void UpDown()
    {
        if (isDead) return;

        if (transform.position.y < maxHeight && Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y = speedY;
            transform.localRotation = Quaternion.Euler(Time.deltaTime, 0.0f, 0.0f);


        }
        else if (transform.position.y > minHeight && Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y = -speedY;
            transform.localRotation = Quaternion.Euler(Time.deltaTime, 0.0f, 0.0f);
        }
        else
        {
            moveDirection.y = 0;

        }
    }

    //左右の移動
    void RightLeft()
    {

        if (isDead) return;

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxRight)
        {
            moveDirection.x = speedX;
            transform.localRotation = Quaternion.identity;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > maxLeft)
        {
            moveDirection.x = -speedX;
            transform.localRotation = Quaternion.identity;
        }
        else
        {
            moveDirection.x = 0;

        }
    }

    //前進
    void Forward()
    {
        if (isDead) return;

        float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);


        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);
    }





    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        string layerName = LayerMask.LayerToName(hit.gameObject.layer);


        //敵か敵の弾に当たったらライフを減らす
        if (layerName == "Enemy" || layerName == "EnemyBullet")
        {
            life--;
            Destroy(hit.gameObject);

        }
        
    }




    void ToGameOver()
    {
        isDead = true;

        //スコアを保存
        PlayerPrefs.SetInt("Score", gameController.GetScore());

        //ハイスコアの保存
        if (PlayerPrefs.GetInt("HighScore") < gameController.GetScore())
        {
            PlayerPrefs.SetInt("HighScore", gameController.GetScore());
        }

        //ゲームオーバー画面へ
        SceneManager.LoadScene("GameOver");
    }







}
