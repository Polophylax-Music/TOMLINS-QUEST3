using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleTextScript : MonoBehaviour
{
    private int count;
    private Text targetText;
    private string Name;
    private int lv;
    private int hp;
    private int mp;
    private int d;
    private int m;
    private int monster;
    private bool one;
    public GameObject NextButton;
    public GameObject BattleButton;
    public GameObject HealButton;
    public GameObject ThunderButton;
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject monster5;

    public void NextClick()
    {
        count++;
    }

    public void BattleClick()
    {
        count = 2;
    }

    public void HealClick()
    {
        count = 4;
    }

    public void ThunderClick()
    {
        count = 5;
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
        monster = Random.Range(1, 4);
        count = 0;
        d = 0; m = 0;
        if (monster == 1)
        {
            monster1.SetActive(true);
            monster2.SetActive(false);
            monster3.SetActive(false);
            monster4.SetActive(false);
            monster5.SetActive(false);
        }
        else if (monster == 2)
        {
            monster1.SetActive(true);
            monster2.SetActive(true);
            monster3.SetActive(true);
            monster4.SetActive(false);
            monster5.SetActive(false);
        }
        else if (monster == 3)
        {
            monster1.SetActive(true);
            monster2.SetActive(true);
            monster3.SetActive(true);
            monster4.SetActive(true);
            monster5.SetActive(true);
        }
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
            count = 1;
        else if (count == -2)
        {
            NextButton.SetActive(true);
            BattleButton.SetActive(false);
            HealButton.SetActive(false);
            ThunderButton.SetActive(false);
            this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\nMPが足りない。";
        }
        else if (count == -1)
            count = 1;
        else if (count == 0)
            this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n魔物が現れた。";
        else if (count == 1)
        {
            this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\nどうする？";
            one = true;
            NextButton.SetActive(false);
            BattleButton.SetActive(true);
            HealButton.SetActive(true);
            ThunderButton.SetActive(true);
        }
        else if (count == 2)
        {
            if (one)
            {
                if (monster == 1)
                {
                    d = Random.Range(0, 11);
                    hp -= d;
                    if (hp <= 0)
                        hp = 0;
                    m = Random.Range(1, 11);
                }
                else if (monster == 2)
                {
                    d = Random.Range(0, 31);
                    hp -= d;
                    if (hp <= 0)
                        hp = 0;
                    m = Random.Range(1, 31);
                }
                else if (monster == 3)
                {
                    d = Random.Range(0, 51);
                    hp -= d;
                    if (hp <= 0)
                        hp = 0;
                    m = Random.Range(1, 51);
                }
                one = false;
            }
            NextButton.SetActive(true);
            BattleButton.SetActive(false);
            HealButton.SetActive(false);
            ThunderButton.SetActive(false);
            this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n" + Name + "は" + d + "ダメージを受けた";
        }
        else if (count == 3)
            count = 6;
        else if (count == 4)
        {
            if (mp < 10)
                count = -2;
            else
                count = -4;
        }
        else if (count == 5)
        {
            if (mp < 30)
                count = -2;
            else
            {
                if (one)
                {
                    mp -= 30;
                    if (monster == 1)
                        m = Random.Range(1, 101);
                    if (monster == 2)
                        m = Random.Range(1, 301);
                    if (monster == 3)
                        m = Random.Range(1, 501);

                    one = false;
                }

                NextButton.SetActive(true);
                BattleButton.SetActive(false);
                HealButton.SetActive(false);
                ThunderButton.SetActive(false);
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\nなんと！森全体に雷が降り注いだ！" + m + "体の魔物が巻き込まれた。";
            }
        }
        else if (count == 6)
        {
            one = true;
            count = 7;
        }
        else if (count == 7)
        {
            if (hp == 0)
                count = -6;
            else
            {
                if (one)
                {
                    lv += m;
                    PlayerPrefs.SetString("Name", Name);
                    PlayerPrefs.SetInt("lv", lv);
                    PlayerPrefs.SetInt("hp", hp);
                    PlayerPrefs.SetInt("mp", mp);
                    PlayerPrefs.Save();
                    one = false;
                }
                monster1.SetActive(false);
                monster2.SetActive(false);
                monster3.SetActive(false);
                monster4.SetActive(false);
                monster5.SetActive(false);
                this.targetText.text = "<size=40>Lv" + lv + "　HP" + hp + "　MP" + mp + "</size>\n\n魔物を倒した。" + Name + "のレベルが" + m + "上がった。";
            }
        }
        else if (count == 8)
        {
            one = true;
            SceneManager.LoadScene("FieldScene");
        }

    }
}
