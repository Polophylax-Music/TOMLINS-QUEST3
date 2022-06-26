using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataCheckTextScript : MonoBehaviour
{

    private Text targetText;
    private string Name;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            Name = PlayerPrefs.GetString("Name");
            this.targetText = this.GetComponent<Text>();
            this.targetText.text = "以下のセーブデータがあります。\n削除しますか？\nセーブデータ：" + Name;
        }
        else
            SceneManager.LoadScene("Name");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
