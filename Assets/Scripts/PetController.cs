using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public int numAllergies;
    public List<AllergySystem.Allergies> foodAllergies = new List<AllergySystem.Allergies>();
    public List<AllergySystem.Allergies> reactions = new List<AllergySystem.Allergies>();

    // Start is called before the first frame update
    void Start()
    {
        ChooseFoodAllergies();
    }

    private void ChooseFoodAllergies()
    {
        for (int i = 0; i < numAllergies; i++)
        {
            AllergySystem.Allergies allergy = AllergySystem.GetRandomAllergy();
            while (foodAllergies.Contains(allergy))
            {
                allergy = AllergySystem.GetRandomAllergy();
            }
            foodAllergies.Add(allergy);
        }
    }

    public void FeedPet(FoodObject foodObject)
    {
        CheckForAllergies(foodObject.food);
    }

    private void CheckForAllergies(FoodItem food)
    {
        reactions.Clear();

        foreach(AllergySystem.Allergies allergy in food.allergies)
        {
            if (foodAllergies.Contains(allergy))
            {
                //Cause symptom of allergy next meal
                Debug.LogWarning("Pet had Allergy to: " + allergy);
                reactions.Add(allergy);
            }
        }
    }
}
