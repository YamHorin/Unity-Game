using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class menuSettingsBehavior : MonoBehaviour
{
    public GameObject mainMenuMusic;
    public GameObject faseImage;
    public GameObject exitMusic;
    AudioSource audioSource;
    string[] subtitles = { "On", "Off" };
    string[] DifficultyLevels = { "easy",  "normal", "hard" };
    public Text subtitleText;
    public Text BackGroundMusicChoise;
    public Text difficultyText;
    int musicOn = 0;
    int currentSubtitle = 0;
    int currentDifficulty = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mainMenuMusic.GetComponent<AudioSource>().isPlaying)
            mainMenuMusic.GetComponent<AudioSource>().Play();
        if (musicOn==1)
        {
            mainMenuMusic.GetComponent<AudioSource>().Stop();
        }

        subtitleText.text = subtitles[currentSubtitle];
        difficultyText.text = DifficultyLevels[currentDifficulty];
        BackGroundMusicChoise.text = subtitles[musicOn];
        staticInfo.isMusicOn = musicOn == 0;
        staticInfo.subtitles = currentSubtitle==0;
        staticInfo.difficulty = currentDifficulty+1;

    }
    public void ChangeMusicRight()
    {
        audioSource.Play();
        musicOn++;
        if (musicOn >= 2)
            musicOn = 0;
    }
    public void ChangeMusicLeft()
    {
        audioSource.Play();
        musicOn--;
        if (musicOn < 0)
            musicOn = 1;
    }

    public void ChangeSubtitleRight()
    {
        audioSource.Play();
        currentSubtitle++;
        if (currentSubtitle >= subtitles.Length)
            currentSubtitle = 0;
    }
    public void ChangeSubtitleLeft()
    {
        audioSource.Play();
        currentSubtitle--;
        if (currentSubtitle <0)
            currentSubtitle = 1;
    }
    public void ChangeDifficultyRight()
    {
        audioSource.Play();
        currentDifficulty++;
        if (currentDifficulty >= DifficultyLevels.Length)
            currentDifficulty = 0;
    }
    public void ChangeDifficultyLeft()
    {
        audioSource.Play();
        currentDifficulty--;
        if (currentDifficulty < 0)
            currentDifficulty = 2;
    }
    IEnumerator LoadScene(int sceneNumber)
    {
        
        faseImage.SetActive(true);
        Animator animator = faseImage.GetComponent<Animator>();
        animator.SetBool("isFading", true);
        yield return new WaitForSeconds(5);
        if (sceneNumber == -1)
            Application.Quit();
        else
            SceneManager.LoadScene(sceneNumber);

    }

    public void BackToMenu()
    {
       exitMusic.GetComponent<AudioSource>().Play();
        StartCoroutine(LoadScene(0));
    }

}
