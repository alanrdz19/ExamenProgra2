using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

   public int ammo;
   public int maxAmmo;
   public float reloadTime;
   
   public Transform firePoint;
   public GameObject proyectile;

   public bool reloading;

   private void Start()
   {
      ammo = maxAmmo;
   }

   private void Update()
   {
      Shoot();
      Reload();
   }

   public void Shoot()
   {
      if (ShootInput() && ammo > 0)
      {
         Instantiate(proyectile, firePoint.position, firePoint.rotation);
         ammo--;
      }
      else if (ShootInput() && ammo == 0 && !reloading)
      {
         StartCoroutine(ReloadGun());
      }
   }

   public void Reload()
   {
      if(CanReload() && ReloadInput())
         StartCoroutine(ReloadGun());
   }

   IEnumerator ReloadGun()
   {
         reloading = true;
         for (int i = 0; ammo < maxAmmo; i++)
         {
            if (ammo == maxAmmo)
            {
               reloading = false;
               break;
            }
            yield return new WaitForSeconds(reloadTime);
            ammo++;
         }
         reloading = false;
   }
   
   public bool CanReload()
   {
      return ammo < maxAmmo && !reloading;
   }

   public bool ReloadInput()
   {
      return Input.GetMouseButtonDown(1);
   }
   
   public bool ShootInput()
   {
      return Input.GetMouseButtonDown(0);
   }
   
}
