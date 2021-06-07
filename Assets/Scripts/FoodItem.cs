using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item", menuName = "New Food Item")]
public class FoodItem : ScriptableObject
{
    public Sprite icon;
    public List<AllergySystem.Allergies> allergies = new List<AllergySystem.Allergies>();
    public Meal meal;
    public bool eaten;

    public FoodItem(Sprite _icon, List<AllergySystem.Allergies> _allergies, Meal _meal)
    {
        icon = _icon;
        allergies = _allergies;
        meal = _meal;
        eaten = false;
    }

    public void Eat()
    {
        eaten = true;
    }

    public enum Meal { Breakfast, Lunch, Dinner }
}
