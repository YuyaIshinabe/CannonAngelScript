using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public GameObject player;

    // 射出するオブジェクト
    [SerializeField, Tooltip("射出するオブジェクトをここに割り当てる")]
    private GameObject throwingObject;

    // 射出角度
    [SerializeField, Range(0F, 90F), Tooltip("射出する角度")]
    private float throwingAngle;

    // 発射間隔
    public float timeBetweenShot = 0.35f;
    private float timer;
    AudioSource shotSound;

    

    private void Start()
    {

        shotSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
       timer += Time.deltaTime;
        

            if (Input.GetKeyDown(KeyCode.Z) && timer > timeBetweenShot)
            {
                timer = 0;
                // Zでボールを射出する
                ThrowingBall();
                shotSound.Play();
            }
        
    }

    // ボールを射出する
    private void ThrowingBall()
    {
        if (throwingObject != null)
        {
            // Ballオブジェクトの生成
            GameObject ball = Instantiate(throwingObject, this.transform.position, Quaternion.identity);

            // 標的の座標 プレイヤーの前方30先
            Vector3 targetPosition = player.transform.position + new Vector3(0, 0, 30);

            // 射出角度
            float angle = throwingAngle;

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            // 射出
            Rigidbody rid = ball.GetComponent<Rigidbody>();
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
        }
        else
        {
            throw new System.Exception("射出するオブジェクトまたは標的のオブジェクトが未設定です。");
        }
    }

    /// <summary>
    /// 標的に命中する射出速度の計算
    /// </summary>
    /// <param name="pointA">射出開始座標</param>
    /// <param name="pointB">標的の座標</param>
    /// <returns>射出速度</returns>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
}
