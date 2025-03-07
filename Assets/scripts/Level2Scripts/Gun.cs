using System.Collections;
using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
    public static Action updateAmmoText;
    [Header("Sound")]
    public AudioClip gunReloadSound;
    public AudioClip gunShotSound;
    public AudioClip emptyGunSound;
    [Header ("refrence")]
    [SerializeField] public GunData gunData;
    [SerializeField] Transform muzzle;
    float timeLastShot;

    private bool canShoot()
    {
        return this.gameObject.activeSelf && gunData.currentAmmo>0 && !gunData.reloading && timeLastShot > 1f / (gunData.fireRate / 60f);
    }
    public void Start()
    {
        playerBehavior.shoot += Shoot;
        playerBehavior.reload += Reload;
        staticInfoGun.currentGun = gunData;
        updateAmmoText?.Invoke();
    }

    public void Shoot()
    {
        if (canShoot())
        {
            if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitInfo, gunData.maxDistance) &&
                hitInfo.collider.name != "Player" )
            
            {
                if (hitInfo.collider != null)
                {

                    Debug.Log("hit " + hitInfo.collider.name);
                    IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();
                    damageable?.TakeDamage(gunData.damage);
                }
            }
             gunData.currentAmmo--;
            Debug.Log("Shot "+gunData.currentAmmo);
            timeLastShot = 0;
            onGunShot();
        }
        else
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = emptyGunSound;
            if (source !=null)
                source.Play();
        }

    }
    public void onGunShot()
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = gunShotSound;
        source.Play();
        updateAmmoText?.Invoke();
    }
    public void Reload()
    {
        if (!gunData.reloading && this.gameObject.activeSelf)
        {
            Debug.Log("Reloading");
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = gunReloadSound;
            source.Play();
            StartCoroutine(reloadIEnumerator());
        }
    }
    private IEnumerator reloadIEnumerator()
    {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magazineSize;
        updateAmmoText?.Invoke();
        gunData.reloading = false;
    }
    public void Update()
    {
        timeLastShot += Time.deltaTime;
    }
    private void OnEnable()
    {
        staticInfoGun.currentGun = gunData;
        updateAmmoText?.Invoke();


    }
   

}
