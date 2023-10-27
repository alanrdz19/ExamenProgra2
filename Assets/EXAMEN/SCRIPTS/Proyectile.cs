using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(90,0,0);
        
        Destroy(gameObject,14);
    }

    private void Update()
    {
        transform.position += new Vector3(0,0,1 * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.collider.tag)
        {
            case "Asteroid":
            {
                Debug.Log("Asteroide");
                Health h = other.collider.GetComponent<Health>();
                h.TakeDamage(1);
                if (h.health <= 0)
                {
                    Destroy(other.gameObject);
                    FindObjectOfType<Score>().AddScore();
                }
                break;
            }
        }
        
        Destroy(gameObject);
    }
}
