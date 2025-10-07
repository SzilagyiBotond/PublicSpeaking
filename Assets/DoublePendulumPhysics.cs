using UnityEngine;

public class DoublePendulumPhysics : MonoBehaviour
{
    public Rigidbody firstRod;        
    public Rigidbody secondRod;       
    public Rigidbody bob;            

    public float firstRodInitialForce = 5f;
    public float secondRodInitialForce = 3f;

    public float firstRodInitialTorque = 2f;
    public float secondRodInitialTorque = 5f;

    void Start()
    {
        firstRod.AddForce(Vector3.right * firstRodInitialForce, ForceMode.Impulse);

        secondRod.AddForce(Vector3.right * secondRodInitialForce, ForceMode.Impulse);

        firstRod.AddTorque(Vector3.forward * firstRodInitialTorque, ForceMode.Impulse);
        secondRod.AddTorque(Vector3.forward * secondRodInitialTorque, ForceMode.Impulse);
    }
}
