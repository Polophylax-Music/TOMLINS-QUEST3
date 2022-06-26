using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditTextScript : MonoBehaviour
{

    private int count;
    private Text targetText;
    private string Name;
    public GameObject NextButton;
    public GameObject YesButton;
    public GameObject NoButton;

    public void NextClick()
    {
        NextButton.SetActive(false);
        YesButton.SetActive(true);
        NoButton.SetActive(true);
        this.targetText.text = "お疲れ様でした。\nこのまま、\"はい\"をクリックすると今のレベルのままでオープニングから開始します。" +
            "\"いいえ\"をクリックするとタイトルに戻ります。";
    }

    public void YesClick()
    {
        PlayerPrefs.SetInt("red", 0);
        PlayerPrefs.SetInt("blue", 0);
        PlayerPrefs.SetInt("yellow", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Opening");
    }

    public void NoClick()
    {
        SceneManager.LoadScene("Title");
    }

    // Start is called before the first frame update
    void Start()
    {
        NextButton.SetActive(true);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "画像提供：「Ｒド」「誰そ彼亭」\n\n音楽提供：「甘茶の音楽工房」\n\nお借りしたUnity無料オブジェクト：" +
            "\n「Red Samurai」　　Sou Chen Ki様\n「Church Model」　　HarpetStudio様\n「Nature Starter Kit 2」　Shapes様";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
