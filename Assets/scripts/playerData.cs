using UnityEngine;
[System.Serializable]
public class playerData
{
    public float playerHealth;
    public int Coins;
    public int Keys;

    public playerData()
    {
        playerHealth = 100;
        Coins = 0;
        Keys = 0;
    }
 
    public void gotHit(float damage)
    {
        playerHealth -= damage * staticInfo.difficulty;
    }
    public void addCoins(int amount)
    {
        Coins += amount;
    }
    public void addKeys(int amount)
    {
        Keys += amount;
    }
    public void useKey()
    {
        Keys--;
    } 
    public void heal(float amount)
    {
        playerHealth += amount;
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
    }




}
