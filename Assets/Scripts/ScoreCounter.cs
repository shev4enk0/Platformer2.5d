using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreCounter : MonoBehaviour
{

    int brokenScore;
    int catchedScore;

    Text brokenScoreText;
    Text catchedScoreText;

    void Start()
    {
        brokenScoreText = GameObject.FindGameObjectWithTag("Broken").GetComponent<Text>();
        catchedScoreText = GameObject.FindGameObjectWithTag("Catched").GetComponent<Text>();
        brokenScore = 0;
        catchedScore = 0;
    }

    void OnEnable()
    {
        Platform.Broken += Broken;
        Hat.Catched += Catched;
    }

    void OnDisable()
    {
        Platform.Broken -= Broken;
        Hat.Catched -= Catched;
    }

    void Broken()
    {
        brokenScore++;
        brokenScoreText.text = brokenScore.ToString();
    }

    void Catched()
    {
        catchedScore++;
        catchedScoreText.text = catchedScore.ToString();
    }
}
