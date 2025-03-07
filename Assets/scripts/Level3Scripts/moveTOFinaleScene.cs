using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class moveTOFinaleScene : MonoBehaviour
{
    Animator Animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator = GetComponent<Animator>();
        DialogManagerLevel3.endScene += nextScene;
    }

    void nextScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        Animator.SetBool("isFading" , true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(5);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
    }
    
}
