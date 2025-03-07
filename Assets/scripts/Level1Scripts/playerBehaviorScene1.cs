using UnityEngine;
using UnityEngine.UI;
public class playerBehaviorScene1 : MonoBehaviour
{
    
    public GameObject player_camera;//connect with unity
    float angular_speed = 20f;
    float speed = 30;
    CharacterController characterController;
    public GameObject musicBackGround;
    public GameObject rainBackGround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rainBackGround.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicBackGround.GetComponent<AudioSource>().isPlaying)
            musicBackGround.GetComponent<AudioSource>().Play();
        if (staticInfo.isMusicOn == false)
        {
            musicBackGround.GetComponent<AudioSource>().Stop();
        }

        float rotation_about_x = Input.GetAxis("Mouse Y") * angular_speed * Time.deltaTime;

        float rotation_about_y = Input.GetAxis("Mouse X") * angular_speed * Time.deltaTime;





        float dz = speed * Time.deltaTime;
        float dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (!Input.GetKey("s") && !Input.GetKey("w"))
            dz = 0;
        if (Input.GetKey("s") && !Input.GetKey("w"))
            dz = dz * -1;


        //rotate camera
        player_camera.transform.Rotate(new Vector3(
            -rotation_about_x, 0));

        //rotate player
        transform.Rotate(new Vector3(0, rotation_about_y, 0));



        //disable for car scene
        ////WE WILL USE IN LOCAL coordinates
        //Vector3 motion = new Vector3(dx, -0.5f, dz);
        ////convert local coordinates into global coordinates
        //motion = transform.TransformDirection(motion);
        //characterController.Move(motion);

    }

}
