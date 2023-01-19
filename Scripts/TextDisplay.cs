using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class TextDisplay : MonoBehaviour
{
    private Text textValues;
    public Charge chargeText;
    public ElectricField EFtext;

    public Text scoreText;
    public static int score;
    
    public int highScore;
    public int scoreMult;

    void Start()
    {
        textValues = GameObject.Find("Math").GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("High Score");
        
    }

    // Update is called once per frame
    void Update()
    {
        textValues.text = "m :  " + chargeText.mass.ToString("F2") + "  Kg\r\n\n"
                         +  "E :  " + EFtext.efieldpass + "  N/C\r\n\n"
                         + "sigma :  " + EFtext.chargeDensity + "  C/m^3\r\n\n"
                         + "Q :  " + chargeText.chargeValue + "  C\r\n\n"
                         + "F :  " + chargeText.force.ToString("F2") + "  N\r\n\n"
                         + "a :  " + chargeText.acceleration.ToString("F2") + " m/s^3\r\n\n"
                         + "v :  " + chargeText.vf.ToString("F2") + "  m/s^2";

        scoreText.text = "score: " + score;
        if (score > highScore)
        {
            PlayerPrefs.SetInt("High Score", score);

        }

    }
    public void addScore()
    {
        score += scoreMult;
    }
}
