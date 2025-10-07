using UnityEngine;

public class FanRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;

    public Transform node1;
    public Transform node2;
    public Transform node3;

    public float segment2Rotation = 15f; 
    public float segment3Rotation = 30f;

    void Update()
    {
        node1.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        //node2.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        //node3.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
