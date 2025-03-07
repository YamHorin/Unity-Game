using System;
using UnityEngine;
using UnityEngine.UI;
public class KeyBehavior : MonoBehaviour
{
    public static Action updateTextKey;
    public Text keyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDisable()
    {
        staticInfo.player.addKeys(1);
        Debug.Log("Key collected OnDisable " + staticInfo.player.Keys);

        if (updateTextKey != null)
        {
            updateTextKey.Invoke();
        }
        else
        {
            Debug.LogWarning("updateTextKey is null, no functions subscribed!");
            keyText.text = "Keys: " + staticInfo.player.Keys + "/" + staticInfo.KEYS;
        }
    }

}
