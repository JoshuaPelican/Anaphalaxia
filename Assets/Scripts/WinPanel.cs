using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinPanel : MonoBehaviour
{
    public TextMeshProUGUI allergiesText;

    void Start()
    {
        PetController p = FindObjectOfType<PetController>();
        allergiesText.text = "The Food Allergies your Pet had were:\n" + p.foodAllergies[0] + "\n" + p.foodAllergies[1] + "\n" + p.foodAllergies[2];
    }
}
