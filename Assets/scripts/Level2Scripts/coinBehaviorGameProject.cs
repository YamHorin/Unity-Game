using System;
using System.Collections;
using UnityEngine;

public class coinBehavior : MonoBehaviour
{
    public static Action updateCoinText;
    AudioSource AudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.Contains("zombie"))
        {
            Debug.Log("Coin collected");
            AudioSource.Play();
            staticInfo.player.addCoins(1);
            updateCoinText?.Invoke();
            StartCoroutine(DestroyCoin());
        
        }
    }
    IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
