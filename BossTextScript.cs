using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossTextScript : MonoBehaviour
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
    public GameObject BossObj;

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
        BossObj.SetActive(true);
        NextButton.SetActive(true);
        BattleButton.SetActive(false);
        HealButton.SetActive(false);
        ThunderButton.SetActive(false);
        Name = PlayerPrefs.GetString("Name");
        lv = PlayerPrefs.GetInt("lv");
        hp = PlayerPrefs.GetInt("hp");
        mp = PlayerPrefs.GetInt("mp");
        count = 2;
        boss = 10000;
        d = 0; m = 0; s = 0;
        this.targetText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
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
                m = Random.Range(0, 1001);
                boss -= m;
                if (boss <= 0)
                    boss = 0;
                one = false;
            }
            NextButton.SetActive(true);
            BattleButton.SetActive(false);
            HealButton.SetActive(false);
            ThunderButton.SetActive(false);
            this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n" + Name + "の攻撃!\n悪魔に" + m + "ダメージを与えた。";
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
                    m = Random.Range(1, 10001);
                    boss -= m;
                    if (boss <= 0)
                        boss = 0;
                    one = false;
                }
                NextButton.SetActive(true);
                BattleButton.SetActive(false);
                HealButton.SetActive(false);
                ThunderButton.SetActive(false);
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\nなんと！悪魔に雷が降り注いだ！" + m + "ダメージを与えた。";
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
                        d = Random.Range(0, 501);
                        hp -= d;
                        if (hp <= 0)
                            hp = 0;
                    }
                    else if (s == 1)
                    {
                        skill = "はデストラクションを放った！";
                        d = Random.Range(0, 1001);
                        hp -= d;
                        if (hp <= 0)
                            hp = 0;
                    }
                }
            }
            this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n悪魔" + skill + "\n" + Name + "は" + d + "ダメージを受けた。";
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
            this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n悪魔：なぜだ…。お前は一体…。";
        }
        else if (count == 10)
        {
            BossObj.SetActive(false);
            this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n…！！どうやら時空が歪みだしたようだ！";
        }
        else if (count == 11)
            SceneManager.LoadScene("Ending");
    }
}
