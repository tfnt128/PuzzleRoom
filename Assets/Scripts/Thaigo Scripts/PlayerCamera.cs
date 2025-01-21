using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Mouse Sentitivity")]
    [SerializeField] private float sensitivityX = 400f;
    [SerializeField] private float sensitivityY = 400f;

    [Header("Mouse Sensitivity smooth rate")]
    [SerializeField] private float smoothTime = 0.04f;

    [Header("Player Real Time Direction")]
    [SerializeField] private Transform direction;

    private float rotationY = 0.0f;
    private float rotationX = 0.0f;
    private float targetRotationY;
    private float targetRotationX;
    private float velocityX = 0.0f;
    private float velocityY = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        targetRotationY += mouseX;
        targetRotationX -= mouseY;
        targetRotationX = Mathf.Clamp(targetRotationX, -90f, 90f);

        rotationX = Mathf.SmoothDamp(rotationX, targetRotationX, ref velocityX, smoothTime);
        rotationY = Mathf.SmoothDamp(rotationY, targetRotationY, ref velocityY, smoothTime);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        direction.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
