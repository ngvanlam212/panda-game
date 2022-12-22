﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider silder;
    // Start is called before the first frame update
    
    public void SetMaxHealth(int health)
    {
        silder.maxValue = health;
        silder.value = health;
    }

    public void SetHealth(int health)
    {
        silder.value = health;
    }

}
