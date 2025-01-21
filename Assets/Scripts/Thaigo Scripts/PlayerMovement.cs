using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement speed")]
    [SerializeField] private float speed = 3f;

    [Header("Player Movement smooth rate")]
    [SerializeField] private float smoothTime = 0.1f;

    [Header("Player Diretion")]
    [SerializeField] private Transform direction;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 currentVelocity = Vector3.zero;

    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void ProcessInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        Vector3 targetDirection = (horizontalInput * direction.right + verticalInput * direction.forward).normalized;
        moveDirection = Vector3.SmoothDamp(moveDirection, targetDirection, ref currentVelocity, smoothTime);
        rb.linearVelocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);
    }
}
