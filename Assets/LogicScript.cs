using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    public Text instructionText;
    [ContextMenu("Level 1_2 Instruction")]
    public void Level1_2Instruction()
    {
        instructionText.text = "Good job, the speech was awesome. Now go to the cafetaria and repeat in a front of a bigger crowd.";
    }
    [ContextMenu("Level 0_1 Instruction")]
    public void Level0_1Instruction()
    {
        instructionText.text = "Today is your big day. Move to your classroom and start your speech.";
    }

    [ContextMenu("Level 2_3 Instruction")]
    public void Level2_3Instruction()
    {
        instructionText.text = "Nice work, you are getting good at this. You have one more task.";
    }
    [ContextMenu("Move Instruction")]
    public void MoveInstruction()
    {
        instructionText.text = "Move to the green box and start the speech";
    }
    [ContextMenu("Level 1 Instruction")]
    public void Level1Instruction()
    {
        instructionText.text = "Do not be shy, speak loud!";
    }

    [ContextMenu("Level 1 Warning on silence")]
    public void Level1Warning()
    {
        instructionText.text = "You're getting good at it, don't stop.";
    }

    [ContextMenu("Level 2 Warning on silence")]
    public void Level2Warning()
    {
        instructionText.text = "Keep up the good work, you can do it.";
    }

    [ContextMenu("Level 2 Instruction")]
    public void Level2Instruction()
    {
        instructionText.text = "Big breath, speak loud!";
    }
    PlayerMovement playerMovement;

    public void disableMovement()
    {
        playerMovement.canMove = false;
    }
    public void enableMovement() 
    { 
        playerMovement.canMove = true;
    }
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    [ContextMenu("Level 1 complete")]
    public void Level1Complete()
    {
        enableMovement();
        Level1_2Instruction();
        GameObject caffDoorA = GameObject.FindGameObjectWithTag("CaffDoorA");
        GameObject caffDoorB = GameObject.FindGameObjectWithTag("CaffDoorB");
        caffDoorA.SetActive(false);
        caffDoorB.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("CubeLevel1"));
        //MeshRenderer meshRendererCaffDoorA = GameObject.FindGameObjectWithTag("CaffDoorA").GetComponent<MeshRenderer>(); 
        //MeshCollider meshColliderCaffDoorA = GameObject.FindGameObjectWithTag("CaffDoorA").GetComponent<MeshCollider>();
        //MeshRenderer meshRendererCaffDoorB = GameObject.FindGameObjectWithTag("CaffDoorB").GetComponent<MeshRenderer>();
        //MeshCollider meshColliderCaffDoorB = GameObject.FindGameObjectWithTag("CaffDoorB").GetComponent<MeshCollider>();

        //meshColliderCaffDoorA.enabled = false;
        //meshRendererCaffDoorA.enabled = false ;
        //meshColliderCaffDoorB.enabled = false;
        //meshRendererCaffDoorB.enabled = false;
    }

    [ContextMenu("Level 2 complete")]
    public void Level2Complete()
    {
        enableMovement();
        Level2_3Instruction();
        Destroy(GameObject.FindGameObjectWithTag("CubeLevel2"));
    }

}
