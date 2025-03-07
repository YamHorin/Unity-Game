using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering;

public class dialogManager : MonoBehaviour
{
    public List<DialogScene2Data> sentences;
    public DialogScene2Data dialogFinal;
    public String nameCharacter;
    public Text subtitles;
    public GameObject player;
    bool startDialog = false;
    bool areaTrigger = false;
    Animator anim;
    AudioSource audioSource;
    int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (areaTrigger)
        {
            if (!startDialog)
                subtitles.text = "press E to speak with "+nameCharacter;
            if (Input.GetKey(KeyCode.E) && !startDialog)
            {
                if (staticInfo.player.Keys == staticInfo.KEYS)
                {
                    index = sentences.Count;
                    startDialog = true;
                    anim.SetBool("talking", true);
                    sentences.Add(dialogFinal);
                    displayDialog();
                }
                else { 
                
                    startDialog = true;
                    index = 0;
                    anim.SetBool("talking", true);
                    displayDialog();
                
                }
            }
            if (Input.GetMouseButtonDown(0) && startDialog)
            {
                displayDialog();
            }
        }

    }
    void displayDialog()
    {


        if (index == sentences.Count)
        {
            subtitles.text = "";
            startDialog = false;
            anim.SetBool("talking", false);
            return;
        }
        Debug.Log("index ="+index);
        DialogScene2Data sentence = sentences[index];
        subtitles.text = sentence.nameCharacter + ": " + sentence.sentence;
        audioSource.clip = sentence.voiceLine;
        audioSource.Play();
        index += 1;


    }
    void OnTriggerEnter(Collider other)
    {

            areaTrigger = true;
        
    }
    void OnTriggerExit(Collider other)
    {

            areaTrigger = false;
            subtitles.text = "";
            startDialog = false;
            anim.SetBool("talking", false);
        
    }

}
