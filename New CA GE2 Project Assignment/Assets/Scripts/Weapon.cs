using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public string weaponName = "MGGun";
    public float shotsPerSecond = 2;
    public GameObject ordinancePrefab;
    public WeaponBarrel weaponBarrel;
    float muzzleVelocity;
    float coolDownTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        weaponBarrel = transform.GetComponentInChildren<WeaponBarrel>();
        muzzleVelocity = ordinancePrefab.GetComponent<Ordinance>().muzzleVelocity;
    }

    public void Fire(Vector3 parentVelocity)
    {

        float coolDownRate = 1 / shotsPerSecond;

        if(coolDownTimer <= Time.time)
        {
            coolDownTimer = Time.time + coolDownRate;

            GameObject newProjectile = Instantiate(ordinancePrefab, weaponBarrel.transform.position, weaponBarrel.transform.rotation) as GameObject;

            Rigidbody projRb = newProjectile.GetComponent<Rigidbody>();

            projRb.velocity = parentVelocity + newProjectile.transform.forward * 300f;
        }

    }
}
