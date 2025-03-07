using System.Collections;
using UnityEngine;
[System.Serializable]
public class Dialogue {
    public bool isLineOfEllie;
    public string sentence;
    public AudioClip voiceLine;

    public Dialogue(bool isLineOfEllie, string sentence, AudioClip voiceLine)
    {
        this.isLineOfEllie = isLineOfEllie;
        this.sentence = sentence;
        this.voiceLine = voiceLine;
    }
    public string getNameCharacter()
    {
        if (isLineOfEllie)
        {
            return "Ellie";
        }
        else
        {
            return "Joe";
        }
    }
    public string getSentence()
    {
        return sentence;
    }
    public AudioClip getVoiceLine()
    {
        return voiceLine;
    }
    
}