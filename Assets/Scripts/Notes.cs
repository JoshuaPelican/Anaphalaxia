using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notes : MonoBehaviour
{
    public GameObject toggle;
    void Start()
    {
        foreach (AllergySystem.Allergies allergy in AllergySystem.GetAllAllergies())
        {
            GameObject newToggle = Instantiate(toggle, transform);
            newToggle.GetComponentInChildren<TextMeshProUGUI>().text = allergy.ToString();
        }
    }
}
