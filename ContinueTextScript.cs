using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueTextScript : MonoBehaviour
{

    private Text targetText;
    private string Name;
    private int count;
    private int red;
    private int blue;
    private int yellow;
    public GameObject NextButton;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject Boss;

    public void NextClick()
    {
        count++;
    }

    public void YesClick()
    {
        count = 7;
    }

    public void NoClick()
    {
        count = 4;
    }

    // Start is called before the first frame update
    void Start()
    {
        NextButton.SetActive(true);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        Boss.SetActive(false);
        count = 0;
        red = PlayerPrefs.GetInt("red");
        blue = PlayerPrefs.GetInt("blue");
        yellow = PlayerPrefs.GetInt("yellow");
        this.targetText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (red == 0 && blue == 0 && yellow == 0)
        {
            if(count == 0)
                this.targetText.text = "さあ、３つの宝玉を探しに行こう。どうやら宝玉はこの教会から３方向に散らばっているようだ。";
            if (count == 1)
                SceneManager.LoadScene("FieldScene");
        }
        else if(red == 1 && blue == 0 && yellow == 0)
        {
            if (count == 0)
                this.targetText.text = "炎の精霊：残りの宝玉は、我がいたところから見て右と左にそれぞれ１つずつ散らばっている。探しに行こう。";
            if (count == 1)
                SceneManager.LoadScene("FieldScene");
        }
        else if (red == 0 && blue == 1 && yellow == 0)
        {
            if (count == 0)
                this.targetText.text = "氷の精霊：残りの宝玉は、私がいたところから見て正面に１つ、左側にもう一つ存在します。さあ、探しに行きましょう。";
            if (count == 1)
                SceneManager.LoadScene("FieldScene");
        }
        else if (red == 0 && blue == 0 && yellow == 1)
        {
            if (count == 0)
                this.targetText.text = "雷の精霊：ホウギョクハ…ワレガイタトコロカラ…ショウメン…ト…ミギ…。サガシニイク…。";
            if (count == 1)
                SceneManager.LoadScene("FieldScene");
        }
        else if (red == 1 && blue == 1 && yellow == 0)
        {
            if (count == 0)
                this.targetText.text = "炎の精霊：最後の宝玉は、我がいたところから見て左にある。";
            if (count == 1)
                this.targetText.text = "氷の精霊：私がいたところから見て正面です。探しに行きましょう。";
            if (count == 2)
                SceneManager.LoadScene("FieldScene");
        }
        else if (red == 1 && blue == 0 && yellow == 1)
        {
            if (count == 0)
                this.targetText.text = "炎の精霊：最後の宝玉は、我がいたところから見て右にある。";
            if (count == 1)
                this.targetText.text = "雷の精霊：ワレガイタトコロカラ…ショウメン…。サガシニイク…。";
            if (count == 2)
                SceneManager.LoadScene("FieldScene");

        }
        else if (red == 0 && blue == 1 && yellow == 1)
        {
            if (count == 0)
                this.targetText.text = "氷の精霊：最後の宝玉は、私がいたところから見て左にあります。";
            if (count == 1)
                this.targetText.text = "雷の精霊：ワレガイタトコロカラ…ミギ…。サガシニイク…。";
            if (count == 2)
                SceneManager.LoadScene("FieldScene");
        }
        else if (red == 1 && blue == 1 && yellow == 1)
        {
            if (count == 0)
                this.targetText.text = "炎の精霊：ようやく、我々３体そろったな。願いを聞こう。";
            if (count == 1)
                this.targetText.text = "雷の精霊：ナルホド…。";
            if (count == 2)
                this.targetText.text = "氷の精霊：見つけました。少し遠くにある城下町にいます。";
            if (count == 3)
            {
                this.targetText.text = "炎の精霊：よし、我々の力でこの教会によびだしてもいいか？";
                NextButton.SetActive(false);
                YesButton.SetActive(true);
                NoButton.SetActive(true);
            }
            if (count == 4)
            {
                this.targetText.text = "氷の精霊：わかりました。準備ができたらまた声をかけてください。";
                NextButton.SetActive(true);
                YesButton.SetActive(false);
                NoButton.SetActive(false);
            }
            if (count == 5)
                this.targetText.text = "雷の精霊：マッテイル…。";
            if (count == 6)
                SceneManager.LoadScene("FieldScene");
            if (count == 7)
            {
                this.targetText.text = "雷の精霊：イマカラ…ショウカン…スル。";
                NextButton.SetActive(true);
                YesButton.SetActive(false);
                NoButton.SetActive(false);
            }
            if (count == 8)
            {
                this.targetText.text = "悪魔：ここは…どこだ？？だ、誰だお前たちは？！";
                Boss.SetActive(true);
            }
            if (count == 9)
                this.targetText.text = "悪魔：せ、精霊？？そうか、お前がここに呼び出したのか。";
            if (count == 10)
                this.targetText.text = "悪魔：せっかく相当頑丈そうな兵士の子供を見つけたんで、せっかく誘拐して化け物に育てようとしてたのにさ！";
            if (count == 11)
                this.targetText.text = "悪魔：まあ、いい。ストレス発散に付き合ってもらうことにするか！";
            if (count == 12)
                SceneManager.LoadScene("Boss");
        }
    }
}
