using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodObject : MonoBehaviour
{
    public FoodItem food;

    public Image icon;
    public TextMeshProUGUI foodNameText;

    private void Start()
    {
        foodNameText.text = food.name;
        icon.sprite = food.icon;
    }

    public void FeedPetEvent()
    {
        FindObjectOfType<PetController>().FeedPet(this);
        food.Eat();
    }

    public void AllowConfirm()
    {
        GameObject.FindGameObjectWithTag("FeedDone").GetComponent<Button>().interactable = true;
    }

    public void DisableAllFood()
    {
        FindObjectOfType<MealTimePanel>().DisableAllFood();
    }
}
