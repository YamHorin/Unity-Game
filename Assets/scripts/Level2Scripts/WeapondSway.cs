using UnityEngine;

public class WeapondSway : MonoBehaviour
{

    [Header("Sway Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float sensitivityMultiplier;

    private Quaternion refRotation;

    private float xRotation;
    private float yRotation;
    Animator Animator;
    public void Start()
    {
        Animator = GetComponent<Animator>();
        playerBehavior.animationGun += gunShotAnimation;
    }

    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivityMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivityMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, speed * Time.deltaTime);
    }
    public void gunShotAnimation()
    {
        Debug.Log("GunShot animation");
        Animator.SetTrigger("gunTrigger");
    }

}
