using UnityEngine;

public class BallLifeCycle : MonoBehaviour
{
    public float lifetime = 5f;
    public bool destroy = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(destroy)
            Destroy(gameObject,lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
