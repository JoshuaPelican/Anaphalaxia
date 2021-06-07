using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MealTimer : MonoBehaviour
{
    public bool timerRunning;

    public TextMeshProUGUI timerText;
    public GameObject mealtimePanel;

    public float maxMealTimer;
    public float currentMealTimer;

    private void Start()
    {
        ResetTimer();
        UpdateTimer();
    }

    private void Update()
    {
        if(currentMealTimer > 0 && timerRunning)
        {
            UpdateTimer();
            currentMealTimer -= Time.deltaTime;
        }
        else
        {
            ToggleTimer(false);
            ResetTimer();
            mealtimePanel.SetActive(true);
        }
    }

    private void ResetTimer()
    {
        currentMealTimer = maxMealTimer;
    }

    private void UpdateTimer()
    {
        timerText.text = "Time Until Next Meal: " + Mathf.RoundToInt(currentMealTimer);
    }

    public void ToggleTimer(bool toggle)
    {
        timerRunning = toggle;
    }
}
