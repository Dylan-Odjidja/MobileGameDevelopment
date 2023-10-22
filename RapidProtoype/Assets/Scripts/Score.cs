using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int ScoreValue = 0;
    public TextMeshProUGUI score;

    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + ScoreValue;
    }
}
