using UnityEngine;
using UnityEngine.UI;
public class CoinsBehaviorScene3 : MonoBehaviour
{
    public Text coinsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            coinsText.text = "Coins: " + staticInfo.player.Coins;
            staticInfo.player.Coins += 1;
            Destroy(gameObject);
        }
    }
}
