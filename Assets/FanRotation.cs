using UnityEngine;

public class FanRotation : MonoBehaviour
{
    // Speed at which each segment will rotate
    public float rotationSpeed = 50f;

    // Reference to the empty nodes (aggregation points for each segment)
    public Transform node1;  // Parent node (root)
    public Transform node2;  // Child node of node1
    public Transform node3;  // Child node of node2

    // Optionally, rotation angles to control the spread of the segments
    public float segment2Rotation = 15f; // Initial rotation for Segment 2
    public float segment3Rotation = 30f; // Initial rotation for Segment 3

    void Update()
    {
        // Rotate the entire parent chain around the Y-axis (global space)
        node1.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Rotate the child nodes around their own local Y-axis, maintaining the parent-child relationship
        //node2.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        //node3.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        //// Optional: Control the spread by rotating the segments (node2 and node3) with their own local rotation
        //node2.localRotation = Quaternion.Euler(0, segment2Rotation, 0);
        //node3.localRotation = Quaternion.Euler(0, segment3Rotation, 0);
    }
}
