using UnityEngine;

public class staticInfo : MonoBehaviour
{
    public const int KEYS = 3;
    static public bool ellieSpeaks = false;
    static public bool subtitles = true;
    static public int difficulty = 2;
    static public bool isMusicOn = true;
    static public int charcterNear = 0;
    static public playerData player;

    static public bool isBossDefeted = false;

    public static void setEllieSpeaks(bool value)
    {
        ellieSpeaks = value;
    }
    void Awake()
    {
        // Ensure this object persists across scenes
        DontDestroyOnLoad(gameObject);
    }


}
