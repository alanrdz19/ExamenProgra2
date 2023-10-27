using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        transform.position += new Vector3(0,0,-1 * speed * Time.deltaTime);
        
        transform.rotation = Quaternion.Euler(0,0,transform.rotation.eulerAngles.z + 1);
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.collider.tag)
        {
            case "Player":
            {
                Health h = other.collider.GetComponent<Health>();
                h.TakeDamage(1);
                FindObjectOfType<HealthUI>().UpdateHealth(h.health);
                
                if(h.health <= 0)
                    Destroy(other.gameObject);
                
                break;
            }
        }
        
        Destroy(gameObject);
        
    }
}
