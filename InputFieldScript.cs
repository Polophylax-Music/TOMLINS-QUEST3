using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class InputFieldScript : MonoBehaviour
{
    InputField inputField;
    private int lv;
    private int hp;
    private int mp;
    private int red;
    private int blue;
    private int yellow;
    private float x;
    private float y;
    private float z;
    public string inputValue;

    public void InputLogger()
    {
        inputValue = inputField.text;
        Confirm();
    }

    public void Confirm()
    {
        if (inputValue == "")
        {
            inputValue = "トムリンズ";
            PlayerPrefs.SetString("Name", inputValue);
            PlayerPrefs.SetInt("lv", lv);
            PlayerPrefs.SetInt("hp", hp);
            PlayerPrefs.SetInt("mp", mp);
            PlayerPrefs.SetFloat("red", red);
            PlayerPrefs.SetFloat("blue", blue);
            PlayerPrefs.SetFloat("yellow", yellow);
            PlayerPrefs.SetFloat("x", x);
            PlayerPrefs.SetFloat("y", y);
            PlayerPrefs.SetFloat("z", z);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Opening");
        }
        else if (inputValue == "lv10000")
        {
            inputValue = "トムリンズ";
            lv = 10000;
            hp = 10010;
            mp = 9999;
            PlayerPrefs.SetString("Name", inputValue);
            PlayerPrefs.SetInt("lv", lv);
            PlayerPrefs.SetInt("hp", hp);
            PlayerPrefs.SetInt("mp", mp);
            PlayerPrefs.SetFloat("red", red);
            PlayerPrefs.SetFloat("blue", blue);
            PlayerPrefs.SetFloat("yellow", yellow);
            PlayerPrefs.SetFloat("x", x);
            PlayerPrefs.SetFloat("y", y);
            PlayerPrefs.SetFloat("z", z);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Opening");
        }
        else if (inputValue == "delete")
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Title");
        }
        else
        {
            PlayerPrefs.SetString("Name", inputValue);
            PlayerPrefs.SetInt("lv", lv);
            PlayerPrefs.SetInt("hp", hp);
            PlayerPrefs.SetInt("mp", mp);
            PlayerPrefs.SetFloat("red", red);
            PlayerPrefs.SetFloat("blue", blue);
            PlayerPrefs.SetFloat("yellow", yellow);
            PlayerPrefs.SetFloat("x", x);
            PlayerPrefs.SetFloat("y", y);
            PlayerPrefs.SetFloat("z", z);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Opening");
        }
            
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        inputField = GetComponent<InputField>();
        inputField.text = "";
        inputField.ActivateInputField();
        lv = 100;
        hp = 110;
        mp = 99;
        x = 227;
        y = 0;
        z = 185;
        red = 0;
        blue = 0;
        yellow = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
