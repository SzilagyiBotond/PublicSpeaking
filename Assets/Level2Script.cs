using UnityEngine;

public class Level2Script : MonoBehaviour
{
    public LogicScript logic;
    public LayerMask whatIsPlayerLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & whatIsPlayerLayer) != 0)
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
            logic.disableMovement();
            logic.Level2Instruction();
        }
    }
}
