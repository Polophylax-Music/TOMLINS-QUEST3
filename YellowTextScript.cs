using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YellowTextScript : MonoBehaviour
{
    private int count;
    private Text targetText;
    private string Name;
    private int lv;
    private int hp;
    private int mp;
    private int d;
    private int m;
    private int s;
    private int boss;
    private int yellow;
    private string skill;
    private bool one;
    public GameObject NextButton;
    public GameObject BattleButton;
    public GameObject HealButton;
    public GameObject ThunderButton;
    public GameObject thunder;

    public void NextClick()
    {
        count++;
    }

    public void BattleClick()
    {
        count = 3;
    }

    public void HealClick()
    {
        count = 5;
    }

    public void ThunderClick()
    {
        count = 6;
    }
    // Start is called before the first frame update
    void Start()
    {
        NextButton.SetActive(true);
        BattleButton.SetActive(false);
        HealButton.SetActive(false);
        ThunderButton.SetActive(false);
        Name = PlayerPrefs.GetString("Name");
        lv = PlayerPrefs.GetInt("lv");
        hp = PlayerPrefs.GetInt("hp");
        mp = PlayerPrefs.GetInt("mp");
        yellow = PlayerPrefs.GetInt("yellow");
        count = 0;
        boss = 5000;
        d = 0; m = 0; s = 0;
        if (yellow == 0)
            thunder.SetActive(true);
        if (yellow == 1)
            thunder.SetActive(false);

        this.targetText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (yellow == 0)
        {
            if (count == 0)
                this.targetText.text = "なんと！雷の宝玉から精霊が出てきた。";
            if (count == 1)
                this.targetText.text = "雷の精霊：ワレワレ二…カッタラ…ネガイ…キク…。";
            if (count == -6)
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\nGAME OVER\n" + Name + "は、力尽きてしまった。\"NEXT\"ボタンでタイトルにもどります。";
            else if (count == -5)
                SceneManager.LoadScene("Title");
            else if (count == -4)
            {
                NextButton.SetActive(true);
                BattleButton.SetActive(false);
                HealButton.SetActive(false);
                ThunderButton.SetActive(false);
                if (one)
                {
                    hp = lv + 10;
                    mp -= 10;
                    one = false;
                }
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n" + Name + "のHPが" + hp + "に回復した。";
            }
            else if (count == -3)
                count = 2;
            else if (count == -2)
            {
                NextButton.SetActive(true);
                BattleButton.SetActive(false);
                HealButton.SetActive(false);
                ThunderButton.SetActive(false);
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\nMPが足りない。";
            }
            else if (count == -1)
                count = 2;
            else if (count == 2)
            {
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\nどうする？";
                one = true;
                NextButton.SetActive(false);
                BattleButton.SetActive(true);
                HealButton.SetActive(true);
                ThunderButton.SetActive(true);
            }
            else if (count == 3)
            {
                if (one)
                {
                    s = Random.Range(0, 2);
                    m = Random.Range(0, 501);
                    boss -= m;
                    if (boss <= 0)
                        boss = 0;

                    one = false;
                }
                NextButton.SetActive(true);
                BattleButton.SetActive(false);
                HealButton.SetActive(false);
                ThunderButton.SetActive(false);
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n" + Name + "の攻撃!\n雷の精霊に" + m + "ダメージを与えた。";
            }
            else if (count == 4)
                count = 7;
            else if (count == 5)
            {
                if (mp < 10)
                    count = -2;
                else
                    count = -4;
            }
            else if (count == 6)
            {
                if (mp < 30)
                    count = -2;
                else
                {
                    if (one)
                    {
                        mp -= 30;
                        one = false;
                    }
                    NextButton.SetActive(true);
                    BattleButton.SetActive(false);
                    HealButton.SetActive(false);
                    ThunderButton.SetActive(false);
                    this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n雷の精霊には効果がないようだ。";
                }
            }
            else if (count == 7)
            {
                if (!one)
                {
                    one = true;
                    if (boss == 0)
                        count = 9;
                    else
                    {
                        if (s == 0)
                        {
                            skill = "の攻撃！";
                            d = Random.Range(0, 51);
                            hp -= d;
                            if (hp <= 0)
                                hp = 0;
                        }
                        else if (s == 1)
                        {
                            skill = "は大陸が震えるような雷を放った！";
                            d = Random.Range(0, 101);
                            hp -= d;
                            if (hp <= 0)
                                hp = 0;
                        }
                    }
                }
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n雷の精霊" + skill + "\n" + Name + "は" + d + "ダメージを受けた。";
            }
            else if (count == 8)
            {
                if (hp == 0)
                    count = -6;
                else
                    count = 2;
            }
            else if (count == 9)
            {

                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n雷の精霊：ミゴト。…キョウカイ。ショウチ。";

            }
            else if (count == 10)
            {
                if (one)
                {
                    lv += 500;
                    one = false;
                }
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n" + Name + "のレベルが500上がった。";
            }
            else if (count == 11)
            {
                PlayerPrefs.SetString("Name", Name);
                PlayerPrefs.SetInt("lv", lv);
                PlayerPrefs.SetInt("hp", hp);
                PlayerPrefs.SetInt("mp", mp);
                PlayerPrefs.SetInt("yellow", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene("FieldScene");
            }
        }
        if (yellow == 1)
        {
            if (count == 0)
                this.targetText.text = "もう、ここには用はない。先に、進もう。";
            if (count == 1)
                SceneManager.LoadScene("FieldScene");
        }
    }
}
