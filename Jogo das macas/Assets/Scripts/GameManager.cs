using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Vector2 screenBounds;
    float score;

    [SerializeField] Text scoreText;

    public static GameManager instance;

    public Vector2 ScreenBounds { get => screenBounds; }

    private void Awake()
    {
        instance = this;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)) + new Vector3(-1,1);
    }

    public void AddScore(int value)
    {
        score+= value;
        scoreText.text = score.ToString();
    }
}
