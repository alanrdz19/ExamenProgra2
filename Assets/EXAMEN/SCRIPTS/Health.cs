using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    public int maxHealth;
    
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health-=damage;
    }

}
