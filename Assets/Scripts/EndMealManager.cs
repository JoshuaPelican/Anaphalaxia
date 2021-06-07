using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMealManager : MonoBehaviour
{
    public List<Symptom> symptoms = new List<Symptom>();

    public Dictionary<Symptom, int> symptomQueue = new Dictionary<Symptom, int>();

    public Dictionary<AllergySystem.Allergies, int> deathCounter = new Dictionary<AllergySystem.Allergies, int>();

    public SpriteRenderer[] symptomObjects;

    public GameObject head;
    public Sprite happyHead;
    public Sprite sadHead;

    public GameObject losePanel;

    public int dailyAllergyCount;

    private void Start()
    {
        foreach (SpriteRenderer symptomObject in symptomObjects)
        {
            symptomObject.gameObject.SetActive(false);
        }

        foreach(AllergySystem.Allergies allergy in AllergySystem.GetAllAllergies())
        {
            deathCounter.Add(allergy, 0);
        }
    }

    public void ResetDay()
    {
        dailyAllergyCount = 0;

        DeathCheck();
    }

    public void EndMeal(List<AllergySystem.Allergies> reactions)
    {
        foreach(SpriteRenderer symptomObject in symptomObjects)
        {
            symptomObject.gameObject.SetActive(false);
        }

        head.GetComponent<SpriteRenderer>().sprite = happyHead;

        Debug.Log("Ended Meal");

        CheckQueue();

        foreach (AllergySystem.Allergies allergy in reactions)
        {
            switch (allergy)
            {
                case AllergySystem.Allergies.Egg:
                    ChooseSymptom(4, 7);
                    deathCounter[AllergySystem.Allergies.Egg] += 1;
                    break;
                case AllergySystem.Allergies.Fish:
                    ChooseSymptom(0, 1);
                    deathCounter[AllergySystem.Allergies.Fish] += 1;
                    break;
                case AllergySystem.Allergies.Gluten:
                    ChooseSymptom(8, 9);
                    deathCounter[AllergySystem.Allergies.Gluten] += 1;
                    break;
                case AllergySystem.Allergies.Milk:
                    ChooseSymptom(1, 2);
                    deathCounter[AllergySystem.Allergies.Milk] += 1;
                    break;
                case AllergySystem.Allergies.Peanut:
                    ChooseSymptom(3, 11);
                    deathCounter[AllergySystem.Allergies.Peanut] += 1;
                    break;
                case AllergySystem.Allergies.RedMeat:
                    ChooseSymptom(1, 6);
                    deathCounter[AllergySystem.Allergies.RedMeat] += 1;
                    break;
                case AllergySystem.Allergies.Shellfish:
                    ChooseSymptom(0, 5);
                    deathCounter[AllergySystem.Allergies.Shellfish] += 1;
                    break;
                case AllergySystem.Allergies.Soy:
                    ChooseSymptom(4, 6);
                    deathCounter[AllergySystem.Allergies.Soy] += 1;
                    break;
                case AllergySystem.Allergies.TreeNuts:
                    ChooseSymptom(3, 10);
                    deathCounter[AllergySystem.Allergies.TreeNuts] += 1;
                    break;
            }
        }
    }

    public void ChooseSymptom(int firstIndex, int secondIndex)
    {
        if (Random.value > .5f)
        {
            ActivateSymptom(symptoms[firstIndex]);
        }
        else
        {
            ActivateSymptom(symptoms[secondIndex]);
        }
    }

    private void DeathCheck()
    {
        foreach (KeyValuePair<AllergySystem.Allergies, int> allergy in deathCounter)
        {
            if(allergy.Value > 3)
            {
                //Pet Death
                losePanel.SetActive(true);
            }
        }
    }

    public void ActivateSymptom(Symptom symptom)
    {
        //if(symptom.delay > 1)
        //{
        //    int randDelay = Random.Range(1, symptom.delay + 1);
        //    if(randDelay > 1)
        //    {
        //        symptomQueue.Add(symptom, randDelay);
        //    }
        //}
        //else
        {
            dailyAllergyCount++;

            //Add visual to pet
            foreach (SpriteRenderer symptomObject in symptomObjects)
            {
                if (symptom.name == symptomObject.name)
                {
                    symptomObject.gameObject.SetActive(true);
                }
            }

            Debug.LogError("Visual Reaction to Allergy: " + symptom.name);
        }

        head.GetComponent<SpriteRenderer>().sprite = sadHead;
    }

    public void CheckQueue()
    {
        foreach (KeyValuePair<Symptom, int> symptom in symptomQueue)
        {
            symptomQueue[symptom.Key] -= 1;
            if(symptomQueue[symptom.Key] == 1)
            {
                ActivateSymptom(symptom.Key);
                symptomQueue.Remove(symptom.Key);
            }
        }
    }
}
