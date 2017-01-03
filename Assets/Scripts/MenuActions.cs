using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class MenuActions : MonoBehaviour {
    PlayGamesClientConfiguration config;
    public void Start() {
        config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
        });
    }
    public void Update() {

    }
    public void playButtonPressed()
    {
        Application.LoadLevel("GameScene");
    }

    public void rankingButtonPressed()
    {
        Social.ShowLeaderboardUI();
        //PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkItK6qkNMKEAIQAQ");
        Debug.Log("ENTER HERE");
    }
}
