using UnityEngine;
using UnityEngine.UI;
public class characterSpeaks : MonoBehaviour
{
    AudioSource audioSource;
    public int talkDistance = 6;
    public string line;
    public bool isLineOfEllie;
    public Text subtitles;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= talkDistance)
        {
           
            if (staticInfo.subtitles==true)
            {
                //update subtitles
                if (isLineOfEllie)
                {
                    subtitles.text = "Ellie: " + line;
                }
                else if (!isLineOfEllie)
                {
                    subtitles.text = "Joe: " + line;
                }
            }
            //update animation of ellie
            if (isLineOfEllie)
            {
                staticInfo.setEllieSpeaks(true);
            }
            else
            {
                staticInfo.setEllieSpeaks(false);
            }
            //play audio
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            subtitles.text = "";
            if (audioSource.isPlaying)
                audioSource.Stop();

        }

        Debug.Log("Updating subtitles: " + subtitles.text);
    }
}
