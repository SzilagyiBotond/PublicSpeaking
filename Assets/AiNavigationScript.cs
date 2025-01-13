using UnityEngine;

public class AiNavigationScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Transform paths;

    [SerializeField]
    private Transform playerCam;

    private Transform currentTarget;
    private int current = 0;

    [SerializeField]
    private float moveSpeed = 0.01f; // Adjust the speed as needed.

    [SerializeField]
    private float rotationSpeed = 10f;

    public bool StartMoving = false;
    void Start()
    {
        currentTarget = paths.GetChild(current);
    }

    void Update()
    {
        if (StartMoving)
        {
            if (currentTarget == null)
            {
                RotateTowardsPlayerCam();
                return;
            }

            animator.Play("RunState");

            Vector2 currentPosXZ = new Vector2(transform.position.x, transform.position.z);
            Vector2 targetPosXZ = new Vector2(currentTarget.position.x, currentTarget.position.z);

            if (Vector2.Distance(currentPosXZ, targetPosXZ) < 0.1f)
            {
                current++;
                if (current < paths.childCount)
                {
                    currentTarget = paths.GetChild(current);
                }
                else
                {
                    // Reached the final target, trigger idle or stop the movement.
                    currentTarget = null;
                    animator.Play("Idle");
                    return;
                }
            }

            // Step 1: Rotate towards the target
            Vector3 targetPosition = new Vector3(currentTarget.position.x, transform.position.y, currentTarget.position.z);
            Vector3 targetDirection = targetPosition - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Smooth rotation towards the target
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Step 2: Check if the rotation is complete
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)  // Rotation is done if the angle is small enough
            {
                // Step 3: Move towards the target only after the rotation is done
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

    private void RotateTowardsPlayerCam()
    {
        if (playerCam != null)
        {
            Vector3 targetPosition = new Vector3(playerCam.position.x, transform.position.y, playerCam.position.z);
            Vector3 directionToCam = targetPosition - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(directionToCam);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
