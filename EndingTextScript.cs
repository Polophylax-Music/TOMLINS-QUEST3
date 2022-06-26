using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingTextScript : MonoBehaviour
{

    private int count;
    private Text targetText;

    public void NextClick()
    {
        count++;
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        this.targetText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
            this.targetText.text = "兵士：！！";
        else if (count == 1)
            this.targetText.text = "王：誰じゃ！？なになに？過去から来たじゃとその時代からというと…。";
        else if (count == 2)
            this.targetText.text = "兵士：私の父が子供の時になりますね。";
        else if (count == 3)
            this.targetText.text = "王：そうか。にわかに信じがたいが…そうじゃ、珍しい格好をしているんで何か見世物でもやってみるのはどうじゃ？";
        else if (count == 4)
            this.targetText.text = "王：何？もういい加減現実世界に帰りたいじゃと？";
        else if (count == 5)
            this.targetText.text = "王：仕方がないのう。案内するのじゃ。";
        else if (count == 6)
            this.targetText.text = "兵士：はっ、それではこちらへ。";
        else if (count == 7)
            this.targetText.text = "GAME CLEAR!!";
        else if (count == 8)
            SceneManager.LoadScene("Credit");
    }
}
