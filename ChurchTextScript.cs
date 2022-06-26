using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChurchTextScript : MonoBehaviour
{
    private Text targetText;
    private string Name;
    private int lv;
    private int hp;
    private int mp;
    private int red;
    private int blue;
    private int yellow;
    private float x;
    private float y;
    private float z;
    public GameObject NextButton;
    public GameObject YesButton;
    public GameObject NoButton;

    public void NextClick()
    {
        PlayerPrefs.SetInt("lv", lv);
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("mp", mp);
        PlayerPrefs.Save();
        this.targetText.text = "まだ続けますか？";
        NextButton.SetActive(false);
        YesButton.SetActive(true);
        NoButton.SetActive(true);
    }

    public void YesClick()
    {
        SceneManager.LoadScene("Continue");
    }

    public void NoClick()
    {
        SceneManager.LoadScene("Title");
    }

    public

    // Start is called before the first frame update
    void Start()
    {
        NextButton.SetActive(true);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        Name = PlayerPrefs.GetString("Name");
        lv = PlayerPrefs.GetInt("lv");
        hp = lv + 10; mp = lv - 1;
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n" + Name + "のHPとMPが全回復した。";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
