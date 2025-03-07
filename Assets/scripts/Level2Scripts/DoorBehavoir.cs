using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DoorBehavoir : MonoBehaviour
{
    public int keysNeeded = 3;
    bool enterTheArea = false;
    public Text subtitle;
    public RawImage RawImage;
    Animator Animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator = GetComponent<Animator>();
        RawImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enterTheArea) {
            int keys  =staticInfo.player.Keys;
            if (keys != keysNeeded )
                subtitle.text = "You need 3 keys to open the door";
            else
                subtitle.text = "Press E to open the door";
            if (Input.GetKeyDown(KeyCode.E) && staticInfo.player.Keys == keysNeeded)
            {
                Animator.SetBool("doorOpening", true);
                StartCoroutine(moveToNextScene());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
            enterTheArea = true;
            RawImage.gameObject.SetActive(true);
        
    }
    private void OnTriggerExit(Collider other)
    {
        enterTheArea = false;
        subtitle.text = "";
        RawImage.gameObject.SetActive(false);

    }
    IEnumerator moveToNextScene()
    {
        //reset the actions
        playerBehavior.reload = null;
        playerBehavior.shoot = null;
        playerBehavior.animationGun = null;
        
        yield return new WaitForSeconds(2);
        RawImage.GetComponent<Animator>().SetBool("isFadingWhite", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
