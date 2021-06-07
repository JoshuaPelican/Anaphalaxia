using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MealTimePanel : MonoBehaviour
{
    private FoodItem.Meal currentMeal = FoodItem.Meal.Breakfast;

    public GameObject foodObject;

    public FoodDatabase data;
    public EndMealManager endMealManager;
    public GameObject endDayPanel;

    public List<GameObject> foodObjects = new List<GameObject>();

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("FeedDone").GetComponent<Button>().interactable = false;

        if(GetComponentsInChildren<FoodObject>() != null)
        {
            foreach (GameObject foodObject in foodObjects)
            {
                Destroy(foodObject.gameObject);
            }

            foodObjects.Clear();
        }

        foreach(FoodItem foodItem in data.foodDatabase)
        {
            if(foodItem.meal == currentMeal)
            {
                GameObject newFoodObject = Instantiate(foodObject, transform);
                foodObjects.Add(newFoodObject);
                FoodObject f = newFoodObject.GetComponent<FoodObject>();
                f.food = foodItem;
                if (f.food.eaten)
                {
                    newFoodObject.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    public void NextMeal()
    {
        endMealManager.EndMeal(FindObjectOfType<PetController>().reactions);

        int nextMeal = ((int)currentMeal + 1);
        if(nextMeal >= Enum.GetValues(typeof(FoodItem.Meal)).Length)
        {
            //End Day
            nextMeal = 0;
            endDayPanel.SetActive(true);

        }

        currentMeal = (FoodItem.Meal)nextMeal;
    }

    public void DisableAllFood()
    {
        foreach(GameObject foodObject in foodObjects)
        {
            foodObject.GetComponent<Button>().interactable = false;
        }
    }
}
