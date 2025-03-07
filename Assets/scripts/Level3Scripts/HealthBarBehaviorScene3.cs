using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviorScene3 : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 100;
    float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = staticInfo.player.playerHealth;
        float targetFillAmount = currentHealth / maxHealth;
        StartCoroutine(updateHealthBarColor());
        healthBar.fillAmount = targetFillAmount;
    }
    IEnumerator updateHealthBarColor()
    {
        healthBar.color = new Color32(255, 0, 0, 100);
        yield return new WaitForSeconds(3f);
        healthBar.color = new Color32(255, 255, 255, 100);

    }
}
