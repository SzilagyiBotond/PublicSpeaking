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


    private bool startCounting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!startCounting)
        {
            return;
        }
        float loudness = detector.GetLoudnessFromMicrophone();
        if (timeToSpeak < 20f)
        {
            timeToSpeak += Time.deltaTime;
        }
        if (loudness < silenceThreshold)
        {
            silenceTime += Time.deltaTime;
            if (timeToSpeak > 20f && silenceTime >= silenceDurationToStop)
            {
                Debug.Log("Silence detected for 3 seconds");
                logic.Level1Complete();
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
        startCounting = true;
    }
}
