using UnityEngine;

public class ellieBehavior : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (staticInfo.ellieSpeaks)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }

    }
}
