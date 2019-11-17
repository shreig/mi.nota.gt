using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score;

    private void Awake()
    {
        CommonObjects.gameController = this;
        CommonObjects.camera = Camera.main;
        CommonObjects.audioListener = CommonObjects.camera.GetComponent<AudioListener>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void AddScore(int score)
    {
        this.score += score;
        UpdateUI();
    }

    public void UpdateUI()
    {
        Text scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        scoreText.text = this.score.ToString();
    }

}
