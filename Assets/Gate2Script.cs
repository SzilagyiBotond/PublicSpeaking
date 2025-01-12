using UnityEngine;

public class Gate2Script : MonoBehaviour
{
    public LogicScript logic;
    private BoxCollider boxCollider;
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
        logic.MoveInstruction();
        boxCollider.enabled = false;
    }
}
