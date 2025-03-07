using System;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class attachWeapondAtStartOfLevel : MonoBehaviour
{
    public static Action updateAmmoText;
    public GameObject wepondSway;
    public GameObject AK47;
    public GameObject M249;
    public GameObject HandGun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        wepondSway.SetActive(true);

        Debug.Log(staticInfoGun.nameGun);
        attachWeapondStartScene(staticInfoGun.nameGun);
      
    }

    private void attachWeapondStartScene(String nameGun)
    {
        switch (nameGun)
        {
            case "AK47":
                attachGameObjectToPlayer(AK47);
                break;
            case "M249":
                attachGameObjectToPlayer(M249);
                break;
            case "handGun":
                attachGameObjectToPlayer(HandGun);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void attachGameObjectToPlayer(GameObject gun)
    {
        AK47.SetActive(false);
        M249.SetActive(false);
        HandGun.SetActive(false);

        gun.SetActive(true);
        Gun gun1 = gun.GetComponent<Gun>();
       

        staticInfoGun.currentGun = Resources.Load<GunData>("Assets/scripts/Level2Scripts/Objects/weapons/"+gun.name+".asset"); ;
        updateAmmoText?.Invoke();
    }
}
