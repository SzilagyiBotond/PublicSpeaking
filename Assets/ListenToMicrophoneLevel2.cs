using System.Collections.Generic;
using UnityEngine;

public class ListenToMicrophoneLevel2 : MonoBehaviour
{
    public LogicScript logic;
    public AudioLoudnessDetection detector;
    public float silenceThreshold = 0.01f;
    public float silenceDurationToStop = 3.0f;
    public float silenceDurationToWarn = 2.0f;
    public float timeToSpeak = 0f;
    public float silenceTime = 0f;
    private int humanCounter = 0;
    private List<AiNavigationScript> aiNavigationScripts;
    public LayerMask whatIsPlayerLayer;

    private bool startCounting = false;
    private bool startListening = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        aiNavigationScripts = new List<AiNavigationScript>
        {
            GameObject.FindGameObjectWithTag("Human28").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human26").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human23").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human11").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human32").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human33").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human18").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human17").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human5").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human24").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human29").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human22").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human19").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human20").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human21").GetComponent<AiNavigationScript>(),
            GameObject.FindGameObjectWithTag("Human16").GetComponent<AiNavigationScript>(),
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (!startListening)
        {
            return;
        }
        float loudness = detector.GetLoudnessFromMicrophone();
        if (!startCounting)
        {
            if (loudness > silenceThreshold)
            {
                startCounting = true;
            }
            else
            {
                return;
            }
        }
        if (timeToSpeak < 20f)
        {
            timeToSpeak += Time.deltaTime;
        }
        if (humanCounter < aiNavigationScripts.Count && timeToSpeak >= (humanCounter + 1) * 1)
        {
            aiNavigationScripts[humanCounter].StartMoving = true;
            humanCounter++;
        }
        if (loudness < silenceThreshold)
        {
            silenceTime += Time.deltaTime;
            if (timeToSpeak > 20f && silenceTime >= silenceDurationToStop)
            {
                Debug.Log("Silence detected for 3 seconds");
                logic.Level2Complete();
            }
            else if (timeToSpeak < 20f && silenceTime >= silenceDurationToWarn)
            {
                logic.Level1Warning();
            }
        }
        else
        {
            silenceTime = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & whatIsPlayerLayer) != 0)
        {
            startListening = true;
        }
    }
}
