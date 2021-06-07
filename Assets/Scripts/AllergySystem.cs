using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
public static class AllergySystem
{
    public enum Allergies {Gluten, Peanut, Milk, Shellfish, TreeNuts, RedMeat, Soy, Egg, Fish};

    public static Allergies GetRandomAllergy()
    {
        Allergies rand = (Allergies)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Allergies)).Length);
        return rand;
    }

    public static List<Allergies> GetAllAllergies()
    {
        return Enum.GetValues(typeof(Allergies)).OfType<Allergies>().ToList();
    }
}
