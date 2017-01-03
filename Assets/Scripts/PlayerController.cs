using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PlayerController : MonoBehaviour {
    
    public float playerSpeed = 0;
    public Text timeLabel;
    public Text bestScoreLabel;

    private Rigidbody2D player;
    private Vector3 pivot = new Vector3(0, 0, 0);
    private bool pressed = false;
    private float totalTime = 0;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        player = GetComponent<Rigidbody2D>();
        pressed = false;
        checkIfNeedShowAd();
	}

    void checkIfNeedShowAd()
    {
        int foo = PlayerPrefs.GetInt("gameplayCounter", 0);
        foo++;
        if (foo >= 10)
        {
            if(Advertisement.IsReady()) Advertisement.Show();
            foo -= 10;
        }
        Debug.Log(foo);
        PlayerPrefs.SetInt("gameplayCounter", foo);
    }

    void playerGoLeft(){
        transform.RotateAround(pivot, new Vector3(0, 0, 1), playerSpeed * Time.deltaTime);
    }

    void playerGoRight() {
        transform.RotateAround(pivot, new Vector3(0, 0, -1), playerSpeed * Time.deltaTime);
    }

    void FixedUpdate() {
        foreach (Touch touch in Input.touches) {
            if (touch.position.x < Screen.width / 2) playerGoLeft();
            else playerGoRight();
        }
        totalTime += Time.deltaTime;
        setTimeLabel();
    }

    private void setTimeLabel(){
        timeLabel.text = "Time: " + totalTime.ToString("F1") + "s";
    }

    void Update () {
       
	}

    private void bestScoreActive(){
        float oldHighscore = PlayerPrefs.GetFloat("highscore", 0);
        if (totalTime > oldHighscore) PlayerPrefs.SetFloat("highscore", totalTime);
        float highScore = PlayerPrefs.GetFloat("highscore", 0);
        bestScoreLabel.text = "Best Score\n" + highScore.ToString("F3") + "s";
        bestScoreLabel.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //implementar fail logic
        timeLabel.text = "Your time is: " + totalTime.ToString("F3") + "s";
        bestScoreActive();
        sendScoreToServer(totalTime, "CgkItK6qkNMKEAIQAQ");
        Time.timeScale = 0;
    }

    private void sendScoreToServer(float score, string s)
    {
        Social.ReportScore((long)(score * 1000), s, (bool success) => {
            // handle success or failure
        });
    }
}
