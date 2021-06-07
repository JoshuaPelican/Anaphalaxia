using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDatabase : MonoBehaviour
{
    public List<FoodItem> foodDatabase = new List<FoodItem>();

    private void Start()
    {
        foreach (FoodItem foodItem in foodDatabase)
        {
            foodItem.eaten = false;
        }
    }
}
