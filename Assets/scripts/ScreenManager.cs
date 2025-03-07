using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScreenManager : MonoBehaviour
{
    public Text coinsText;
    public Text keyText;
    public Text AmmoText;
    public Image healthBar;
    float maxHealth = 100;
    float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        updateHealthBar();
        updateCoinsText();
        playerBehavior.updateHealthText += updateHealthBar ;
        Gun.updateAmmoText += updateAmmo;
        coinBehavior.updateCoinText += updateCoinsText;
        updateAmmo();
        KeyBehavior.updateTextKey += updateKeyText;
        attachWeapondAtStartOfLevel.updateAmmoText += updateAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateAmmo()
    { 

        if (staticInfoGun.currentGun == null)
        { 
            Debug.Log(" gun is null");
            AmmoText.text = "";
        }
        if (AmmoText != null)
        {
            AmmoText.text = "Ammo: " + staticInfoGun.currentGun.currentAmmo + "/" + staticInfoGun.currentGun.magazineSize;
        }


    }
    void updateHealthBar()
    {
        currentHealth = staticInfo.player.playerHealth;
        float targetFillAmount = currentHealth / maxHealth;
        StartCoroutine( updateHealthBarColor());
        healthBar.fillAmount = targetFillAmount;
    }
    public void updateCoinsText()
    {
        coinsText.text = "Coins: " + staticInfo.player.Coins;
    }
    public void updateKeyText()
    {
        Debug.Log("Key Text Updated");
        keyText.gameObject.SetActive(true);
        keyText.text = "Keys: " + staticInfo.player.Keys +"/"+ staticInfo.KEYS;
        
    }
    IEnumerator updateHealthBarColor()
    {
        healthBar.color = new Color32(255, 0, 0, 100);
        yield return new WaitForSeconds(3f);
        healthBar.color = new Color32(255, 255, 255, 100);
        
    }
    void OnEnable()
    {
        updateHealthBar();
        updateCoinsText();
        playerBehavior.updateHealthText += updateHealthBar;
        Gun.updateAmmoText += updateAmmo;
        coinBehavior.updateCoinText += updateCoinsText;
        updateAmmo();
        KeyBehavior.updateTextKey += updateKeyText;
        attachWeapondAtStartOfLevel.updateAmmoText += updateAmmo;
    }
    private void OnDestroy()
    {
        playerBehavior.updateHealthText = null;
        coinBehavior.updateCoinText = null;
        Gun.updateAmmoText = null;

    }

}
