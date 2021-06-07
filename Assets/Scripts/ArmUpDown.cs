using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmUpDown : MonoBehaviour
{
    public GameObject downArm;

    private void OnDisable()
    {
        downArm.SetActive(true);
    }
    private void OnEnable()
    {
        downArm.SetActive(false);
    }
}
