using System;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName ="Gun" , menuName ="Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("info")]
    public string gunName;

    [Header("Gun Settings")]
    public float damage;
    public float maxDistance;

    [Header("Ammo Settings")]
    public int magazineSize;
    public int currentAmmo;
    public float fireRate;

    [Header("Reload Settings")]
    public float reloadTime;
    public bool reloading;

    override public string ToString()
    {
        return gunName +"  " + magazineSize +"  " + currentAmmo;
    }
   

}
