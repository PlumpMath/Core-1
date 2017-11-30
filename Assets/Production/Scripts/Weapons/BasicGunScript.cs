using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGunScript : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    public int damage = 1;
    
    void Star(){
        fireRate = 1.5f;
    }
    public void FireWeapon(GameObject target){
      if (Time.time > nextFire)
        {   
           float newFireRate = fireRate - (ResourcesScript.Instance.upgradeGunFireRate + ResourcesScript.Instance.upgradeGunFireRateTwo );
            nextFire = Time.time + newFireRate;
            GameObject shotObject =  Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            shotObject.GetComponent<fireScript>().damage = damage + ResourcesScript.Instance.upgradeGunDamage;
            shotObject.GetComponent<fireScript>().GetTarget(target);
        }  
    }

}