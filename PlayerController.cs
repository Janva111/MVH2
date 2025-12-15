using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float turnSpeed = 150f;

    //Najděte jakkoliv rigidbody
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("RigidBody je null");
        }
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");

        Vector3 moveVelocity = transform.forward * moveInput * moveSpeed;

        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);

        float turnInput = Input.GetAxis("Horizontal");

        float turnAmount = turnInput * turnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
