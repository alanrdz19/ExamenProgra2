using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Text health;

    private void Start()
    {
        health.text = "Vida: " + GameObject.FindWithTag("Player").GetComponent<Health>().health;
    }

    public void UpdateHealth(int health)
    {
        this.health.text = "Vida: " + health;
    }   
    
}
