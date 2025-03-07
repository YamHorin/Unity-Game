using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class finalSceneBehavior : MonoBehaviour
{
    public Text scoreText;
    public RawImage rawImage;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText.text = "Coins Collected: " + staticInfo.player.Coins;
        rawImage.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            mainMenu();
        }
    }

    public  void mainMenu()
    {
        rawImage.gameObject.SetActive(true);
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        audioSource.Play();
        rawImage.gameObject.SetActive(true);
        rawImage.GetComponent<Animator>().SetBool("isFading", true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

}
