using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int points = 0;
    public TMP_Text scoreText;
    public TMP_Text targetText;
    public Slider timerSlider;

    public static UIManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else 
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = $"points {points}";
    }

    public void SetMaxValue(float maxValue)
    {
        timerSlider.maxValue = maxValue;
    }

    public void setSlider(float value)
    {
        timerSlider.value = value;
    }

    public void UpdateTargetText(string value)
    {
        targetText.text = "Target is " + value;
    }

    public void AddPoints()
    {
        points++;
        scoreText.text = $"points {points}";
    }
    public void RemovePoints()
    {
        points--;
        scoreText.text = $"points {points}";
    }
}
