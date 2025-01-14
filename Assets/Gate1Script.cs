using UnityEngine;

public class Gate1Script : MonoBehaviour
{
    public LogicScript logic;
    private BoxCollider boxCollider;
    public LayerMask whatIsPlayerLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & whatIsPlayerLayer) != 0)
        {
            logic.MoveInstruction(); // Execute logic if the condition is met
            GameObject.Destroy(gameObject);
        }
    }
}
