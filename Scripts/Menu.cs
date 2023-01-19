using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    public Button shopButton;
    private string highScoreTxt;
    public Text highScore;
    private AudioSource source;

    void Start()
    {
        highScoreTxt = PlayerPrefs.GetInt("High Score").ToString();
        highScore.text = "High Score: "+highScoreTxt;
        source = GetComponent<AudioSource>();
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        highScoreTxt = PlayerPrefs.GetInt("High Score").ToString();
        highScore.text = "High Score: " + highScoreTxt;
    }
    public void loadEasy()
    {
        SceneManager.LoadScene("game");
    }
    public void loadMedium()
    {
        SceneManager.LoadScene("game medium");
    }
    public void loadHard()
    {
        SceneManager.LoadScene("game hard");
    }
    public void loadShop()
    {

    }
}
