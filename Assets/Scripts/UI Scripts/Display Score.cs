using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text levelText;
    private GameBoardController scoringScript;

    void Start()
    {
        scoringScript = Camera.main.GetComponent<GameBoardController>();
    }

    void Update()
    {
        scoreText.text = scoringScript.totalScore.ToString();
        levelText.text = scoringScript.currentLevel.ToString();

    }

}
