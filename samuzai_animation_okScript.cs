using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class samuzai_animation_okScript : MonoBehaviour
{
    //private float speed;
    public float speed;
    public float rotatespeed;
    private float step;
    private float enemy;
    private float x;
    private float y;
    private float z;
    private Vector3 velocity;
    private Vector3 player_pos;
    private Vector3 player_rot;

    // Start is called before the first frame update
    void Start()
    {
        step = 0f;
        enemy = Random.Range(40f, 50f);
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");
        transform.localPosition = new Vector3(x, 0f, z);
        transform.Rotate(0f, y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        player_pos = transform.position;
        player_rot = gameObject.transform.localEulerAngles;
        float v = Input.GetAxis("Vertical");
        velocity = new Vector3(0f, 0f, v);
        velocity = transform.TransformDirection(velocity);
        if (player_pos.x < 100)
            transform.localPosition = new Vector3(100f, 0f, player_pos.z);
        else if (player_pos.x > 400)
            transform.localPosition = new Vector3(400f, 0f, player_pos.z);
        else if (player_pos.z < 100)
            transform.localPosition = new Vector3(player_pos.x, 0f, 100f);
        else if (player_pos.z > 400)
            transform.localPosition = new Vector3(player_pos.x, 0f, 400f);
        else
            transform.localPosition += velocity * Time.deltaTime * speed;
        transform.Rotate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotatespeed, 0f);

        // 教会へ移動
        if (player_pos.x > 245 && player_pos.z > 170 && player_pos.x < 250 && player_pos.z < 190)
        {
            PlayerPrefs.SetFloat("x", 227);
            PlayerPrefs.SetFloat("y", 0);
            PlayerPrefs.SetFloat("z", 185);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ChurchScene");
        }
        // 炎の宝玉
        if (player_pos.x > 220 && player_pos.z > 360 && player_pos.x < 240 && player_pos.z < 380)
        {
            PlayerPrefs.SetFloat("x", 230);
            PlayerPrefs.SetFloat("y", 180);
            PlayerPrefs.SetFloat("z", 340);
            PlayerPrefs.Save();
            SceneManager.LoadScene("RedScene");
        }

        // 氷の宝玉
        if (player_pos.x > 120 && player_pos.z > 230 && player_pos.x < 140 && player_pos.z < 250)
        {
            PlayerPrefs.SetFloat("x", 170);
            PlayerPrefs.SetFloat("y", 90);
            PlayerPrefs.SetFloat("z", 240);
            PlayerPrefs.Save();
            SceneManager.LoadScene("BlueScene");
        }

        // 雷の宝玉
        if (player_pos.x > 360 && player_pos.z > 240 && player_pos.x < 380 && player_pos.z < 260)
        {
            PlayerPrefs.SetFloat("x", 330);
            PlayerPrefs.SetFloat("y", -90);
            PlayerPrefs.SetFloat("z", 250);
            PlayerPrefs.Save();
            SceneManager.LoadScene("YellowScene");
        }

        // 敵
        if (v != 0)
            step++;
        if (step > enemy)
        {
            PlayerPrefs.SetFloat("x", player_pos.x);
            PlayerPrefs.SetFloat("y", player_rot.y);
            PlayerPrefs.SetFloat("z", player_pos.z);
            PlayerPrefs.Save();
            SceneManager.LoadScene("BattleScene");
        }
    }
}
