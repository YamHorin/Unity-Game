using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class DialogueManager : MonoBehaviour
{
    public GameObject image;
    public List<Dialogue> sentences;
    public Text subtitles;
    int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        DisplayNextSentence();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (index == sentences.Count)
        {
            return;
        }
        Dialogue sentence = sentences[index];
        if (sentence.isLineOfEllie)
        {
            staticInfo.ellieSpeaks = true;
        }
        else
        {
            staticInfo.ellieSpeaks = false;
        }

        subtitles.text = sentence.getNameCharacter() +": "+sentence.getSentence();
        if (sentence.getSentence() == "")
        {
            subtitles.text = "";
            StartCoroutine(moveToNextScene());
        }
        playAudio(sentence.getVoiceLine());
        index += 1;
    }
    void playAudio(AudioClip voiceLine)
    {
        if (voiceLine != null)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = voiceLine;
            audio.Play();
        }
    }
    IEnumerator moveToNextScene()
    {
        float delay = 4f;
        image.SetActive(true);
        yield return new WaitForSeconds(delay+2f);
        image.GetComponent<Animator>().SetBool("isFading",true);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }

}
