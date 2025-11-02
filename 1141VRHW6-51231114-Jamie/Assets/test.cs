using UnityEngine;

public class test : MonoBehaviour
{
    [Header("飛行設定")]
    public float speed = 5f;       // 移動速度
    public float turnSpeed = 50f;  // 轉向速度

    [Header("音效")]
    public AudioSource flySound;      // 飛行聲
    public AudioSource crashSound;    // 撞擊聲
    public AudioSource successSound;  // 過關聲

    void Start()
    {
        // 播放飛行聲
        if (flySound != null)
        {
            flySound.loop = true;
            flySound.Play();
        }
    }

    void Update()
    {
        // 飛行控制
        float h = Input.GetAxis("Horizontal"); // 左右
        float v = Input.GetAxis("Vertical");   // 前後
        float y = 0;

        if (Input.GetKey(KeyCode.E)) y = 1;   // 上升
        if (Input.GetKey(KeyCode.Q)) y = -1;  // 下降

        Vector3 move = new Vector3(h, y, v) * speed * Time.deltaTime;
        transform.Translate(move, Space.Self);
        transform.Rotate(0, h * turnSpeed * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 撞到障礙物播放撞擊聲
        if (collision.gameObject.CompareTag("Obstacle") && crashSound != null)
        {
            crashSound.Play();
        }

        // 撞到終點播放成功聲
        if (collision.gameObject.CompareTag("Goal") && successSound != null)
        {
            successSound.Play();
        }
    }
}