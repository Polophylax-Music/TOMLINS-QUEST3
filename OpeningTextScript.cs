using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningTextScript : MonoBehaviour
{
    private int count;
    private Text targetText;
    private string Name;
    public GameObject NextButton;
    public GameObject YesButton;
    public GameObject NoButton;

    public void NextClick()
    {
        count++;
    }

    public void YesClick()
    {
        count = 6;
    }

    public void NoClick()
    {
        count = -1;
    }


    // Start is called before the first frame update
    void Start()
    {
        NextButton.SetActive(true);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        count = 0;
        Name = PlayerPrefs.GetString("Name");
        this.targetText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
            this.targetText.text = "王：久しぶりじゃな。ついこの間までこの城の地下で閉じ込められていた王じゃ。";
        else if (count == 1)
            this.targetText.text = "王：３つの宝玉に宿った精霊の力で何とか脱出してきたところじゃ。";
        else if (count == 2)
            this.targetText.text = "王：ついさっき、３つの宝玉から聞いたのじゃが、魔王はあの精霊の力を利用し不死身の力を手に入れることができたらしい。";
        else if (count == 3)
            this.targetText.text = "王：しかも、そのことを教えたものがちょうどわしが子供の時にいたらしい。";
        else if (count == 4)
            this.targetText.text = "王：そういうわけで、とりあえず過去に飛んで一人の人間を魔王に変えてしまったものを倒してきてほしい。";
        else if (count == 5)
        {
            this.targetText.text = "王：引き受けてくれるかの？";
            NextButton.SetActive(false);
            YesButton.SetActive(true);
            NoButton.SetActive(true);
        }
        else if (count == 6)
        {
            this.targetText.text = "王：よくぞ言ってくれた。";
            NextButton.SetActive(true);
            YesButton.SetActive(false);
            NoButton.SetActive(false);
        }
        else if (count == 7)
            this.targetText.text = "王：それでは勇者…そうじゃったまず何をするのか説明しないと。";
        else if (count == 8)
            this.targetText.text = "王：まず、ここにある３つの宝玉の力を借りて過去に飛ぶ、すると多分教会の前に飛ぶはずじゃ。";
        else if (count == 9)
            this.targetText.text = "王：そう、むかしここら辺は村などなくただ教会があるだけじゃった。もともとこの国も別のところにあったのじゃ。";
        else if (count == 10)
            this.targetText.text = "王：じゃが、ある日ちょっと料理をしようと思ってな、やってみたんじゃが火の消し忘れで城全体、いや城下町全体が火事になってな。";
        else if (count == 11)
            this.targetText.text = "王：幸い、不思議なことにけが人はだれ一人出なかったのじゃが、復旧するよりか新しいところに住みたいという事になって。";
        else if (count == 12)
            this.targetText.text = "王：そしたら広い土地に誰もいない教会をみつけたんで、そこにまた城を建てようと思って今に至るのじゃ。";
        else if (count == 13)
            this.targetText.text = "王：城を建てた後は、わしの近くに居たくないという人々が勝手に街や村を作っていったのじゃ。";
        else if (count == 14)
            this.targetText.text = "王：話を戻すと過去に飛んだあと、まだ強い力を持っていたころの精霊を探すのじゃ。";
        else if (count == 15)
            this.targetText.text = "王：そして、その精霊の力を借りて\"魔王\"を\"魔王\"にした悪魔を探し出して倒してきてほしい。";
        else if (count == 16)
            this.targetText.text = "炎の宝玉：そのころ我々は多分、宝玉の中で眠っているはずだ。街ができてもその場でに居たことは３人とも覚えている。";
        else if (count == 17)
            this.targetText.text = "王：だそうじゃ。過去にはこの３つの宝玉が飛ばしてくれるらしい。";
        else if (count == 18)
            this.targetText.text = "王：そうじゃ、武器にこの刀と新しい鎧をプレゼントしよう。";
        else if (count == 19)
            this.targetText.text = Name + "は、勇者の刀と勇者の鎧Ⅱを手に入れた。";
        else if (count == 20)
            this.targetText.text = "王：それでは、行くがいい勇者" + Name + "よ。";
        else if (count == 21)
            this.targetText.text = "今回は王様が勇者の呼び戻しに、とりあえず成功したため、Lv100からのスタートとなっています。";
        else if (count == 22)
            this.targetText.text = "\"たたかう\"は武器を使ってたたかう、\"ヒール\"はMPを10消費してHPを全回復、\"サンダー\"はMPを30消費して雷を落とすことができます。";
        else if (count == 23)
            this.targetText.text = "…！！どうやら時空が歪みだしたようだ！";
        else if (count == 24)
            SceneManager.LoadScene("FieldScene");
        else if (count == -1)
            this.targetText.text = "王：まあ、そんなことを言わずに。";
    }
}
