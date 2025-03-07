using System;
using UnityEngine;

public class playerBehavior : MonoBehaviour, IDamageable
{
    public static Action animationGun;
    public static Action shoot;
    public static Action reload;
    public static Action updateHealthText;
    public GameObject player_camera;//connect with unity
    public GameObject soundHurt;//connect with unity
    public float speed = 20;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    float rotationX = 0;

    public bool canMove = true;

    AudioSource audioSource;
    CharacterController characterController;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        shoot = null;
        reload = null;
        animationGun = null;
        updateHealthText = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot?.Invoke();
            animationGun?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            reload?.Invoke();
        }




        float dz = speed * Time.deltaTime;
        float dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (!Input.GetKey("s") && !Input.GetKey("w"))
            dz = 0;
        if (Input.GetKey("s") && !Input.GetKey("w"))
            dz = dz * -1;
        if (dx != 0 || dz != 0)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        Vector3 motion = new Vector3(dx, -0.1f, dz);
        motion = transform.TransformDirection(motion);
        characterController.Move(motion);


        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            player_camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }

    public void TakeDamage(float damage)
    {
        //play sound
        soundHurt.GetComponent<AudioSource>().Play();
        staticInfo.player.gotHit(damage);
        Debug.Log("Player Health: " + staticInfo.player.playerHealth);  
        updateHealthText?.Invoke();

    }
}
