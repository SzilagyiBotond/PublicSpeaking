using UnityEngine;

public class SchoolGateScript : MonoBehaviour
{
    public LayerMask whatIsPlayerLayer;
    public GameObject schoolClosedDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & whatIsPlayerLayer) != 0)
        {
            GameObject.FindGameObjectWithTag("SchoolOpenDoorA").SetActive(false);
            GameObject.FindGameObjectWithTag("SchoolOpenDoorB").SetActive(false);
            //GameObject.FindGameObjectWithTag("SchoolClosedDoor").SetActive(true);
            schoolClosedDoor.SetActive(true);
            GameObject.Destroy(gameObject);
        }
    }
}
