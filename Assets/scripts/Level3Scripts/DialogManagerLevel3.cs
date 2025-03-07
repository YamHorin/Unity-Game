using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagerLevel3 : MonoBehaviour
{
    public static Action startBattle;
    public static Action endScene;
    [Header("Dialogs")]
    public List<DialogScene2Data> dialogsBeforeFight;
    public List<DialogScene2Data> dialogsAfterFight;


    [Header("other things")]
    public string nameCharacter;
    public GameObject player;
    public Text subtitles;
    [Header("Gem")]
    public GameObject Gem;
    bool areaTrigger = false;
    bool stratDialog = false;

    int index = 0;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool boss = staticInfo.isBossDefeted;
        
        if (areaTrigger)
        {
            if (boss)
            {
                 Gem.SetActive(true);
                if (!stratDialog)
                    subtitles.text = "press E to get the gem";

            }
            if (!stratDialog)
                subtitles.text = "press E to speak with " + nameCharacter;
            if (Input.GetKey(KeyCode.E) && !boss)
            {
                stratDialog = true;
                index = 0;
                Debug.Log("dialog " + index);
                displayDialog(dialogsBeforeFight);
            }
            if (Input.GetKey(KeyCode.E)  && boss)
            {
                stratDialog = true;
                index = 0;
                displayDialog(dialogsAfterFight);
            }
            if (Input.GetKeyDown("space") && stratDialog)
            {
                Debug.Log("dialog " + index);
                if (boss)
                    displayDialog(dialogsAfterFight);
                else
                    displayDialog(dialogsBeforeFight);
            }

        }
    }

    private void displayDialog(List<DialogScene2Data> dialogs)
    {
        if (index < dialogs.Count)
        {
            subtitles.text =dialogs[index].nameCharacter+":"+dialogs[index].sentence;
            audioSource.clip = dialogs[index].voiceLine;
            audioSource.Play();
            index++;
        }
        else
        {
            subtitles.text = "";
            if (!staticInfo.isBossDefeted)
                startBattle?.Invoke();
            if (staticInfo.isBossDefeted)
                endScene?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
            areaTrigger = true;
        
    }
    void OnTriggerExit(Collider other)
    {
        areaTrigger = false;
        subtitles.text = "";
    }


}
