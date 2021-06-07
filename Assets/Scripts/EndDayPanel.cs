using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndDayPanel : MonoBehaviour
{
    public TextMeshProUGUI reactionsNumText;
    public TextMeshProUGUI petHealthText;

    public EndMealManager endMeal;

    public GameObject winPanel;

    public int day = 1;

    private void OnEnable()
    {
        day++;

        reactionsNumText.text = "Number of Allergic Reactions Today: " + endMeal.dailyAllergyCount;
    }

    public void CheckWin()
    {
        if(day == 4)
        {
            winPanel.SetActive(true);
        }
    }
}
