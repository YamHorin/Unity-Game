using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
public class WeaponPickUpBehavior : MonoBehaviour
{
    public static Action attachGunToData;
    public static Action updateKeyText;
    [Header("camera")]
    public GameObject player_camera;//connect with unity
    [Header("weapons")]
    public GameObject WeapondSway;
    public GameObject AK47;
    public GameObject M249;
    public GameObject HandGun;
    [Header("other")]

    public Text subtitle;
    public AudioClip audioClipPickUpGun;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (staticInfoGun.currentGun != null)
        {
            Debug.Log(staticInfoGun.currentGun.name);
            WeapondSway.SetActive(true);
            attachWeapondStartScene(staticInfoGun.currentGun);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if ( Physics.Raycast(
            player_camera.transform.position,
            player_camera.transform.forward,
            out hit) && WeapondSway.activeSelf == true
            )
        {


            switch (hit.collider.gameObject.name)
            {
                case "AK47_ground":
                    subtitle.text = "Press E to pick up AK47";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pickUpGun(AK47);
                    }
                    break;
                case "M249_ground":
                    subtitle.text = "Press E to pick up M249";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pickUpGun(M249);
                    }
                    break;
                case "HandGun_ground":
                    subtitle.text = "Press E to pick up HandGun";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pickUpGun(HandGun);
                    }
                    break;
                case "key":
                    subtitle.text = "Press E to pick up Key";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        audioSource.clip = audioClipPickUpGun;
                        audioSource.Play();
                        hit.collider.gameObject.SetActive(false);
                        Debug.Log("picked up key game object is diable");
                        subtitle.text = "";
                    }
                    break;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        subtitle.text = "";
    }
    private void OnTriggerEnter(Collider other)
    {
        WeapondSway.SetActive(true);
        subtitle.gameObject.SetActive(true);
        subtitle.text = "";
    }
    void pickUpGun(GameObject gun)
    {
        AK47.SetActive(false);
        M249.SetActive(false);
        HandGun.SetActive(false);
        audioSource.clip = audioClipPickUpGun;
        audioSource.Play();
        gun.SetActive(true);
        GunData gunData = gun.GetComponent<Gun>().gunData;
        Gun gun1 = gun.GetComponent<Gun>();
        staticInfoGun.currentGun = gunData;
        staticInfoGun.nameGun = gunData.name;
        Debug.Log("picked up " + staticInfoGun.currentGun.name);
        playerBehavior.shoot += gun1.Shoot;
        playerBehavior.reload += gun1.Reload;
        

    }
    void attachWeapondStartScene(GunData currentGun)
    { 
        switch (currentGun.name)
        {
            case "AK47":
                pickUpGun(AK47);
                break;
            case "M249":
                pickUpGun(M249);
                break;
            case "HandGun":
                pickUpGun(HandGun);
                break;
            
        }
    }
}
