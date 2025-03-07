using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class menuBehavior : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject mainMenuMusic;
    public GameObject faseImage;
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
        
        if (staticInfo.isMusicOn == false)
        {
            mainMenuMusic.GetComponent<AudioSource>().Stop();
        }

    }
    public void goToSetting()
    {
        audioSource.Play();
        StartCoroutine(LoadScene(4));
    }
    public void PlayGame()
    {
        audioSource.Play();
        staticInfo.player = new playerData();
        staticInfoGun.currentGun = null;
        StartCoroutine(LoadScene(1));
    }
    public void QuitGame()
    {
        audioSource.Play();
        StartCoroutine(LoadScene(-1));
    }
    public void BackToMenu()
    {
        audioSource.Play();
        StartCoroutine( LoadScene(0));
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

}
