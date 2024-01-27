using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class DialogueTimer : MonoBehaviour
{
    public static DialogueTimer Instance { get; private set; }

    [SerializeField] private Button StartClick;
    [SerializeField] private Button Happy;
    [SerializeField] private PlayableDirector AudioDir;
    [SerializeField] private float TimerCheck;

    private bool Sound2Check;
    public bool EnableTiming = false;
    public bool FailCheck = false;

    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Happy.onClick.AddListener(StartingClick);
    }

    private void StartingClick()
    {
        Sound2Check = true;
        Debug.Log("Clicked!");
    }

    public void StartButton()
    {
        AudioDir.Play();
    }

    public void EnableTime(int emotions)
    {
        EnableTiming = true;
        FindObjectOfType<SoundButtonManager>().SetInputTakeable(IntToEnum(emotions));
    }

    public EnumSoundType IntToEnum(int num)
    {
        return (EnumSoundType)num;
    }

    public void FailFlag()
    {
        FailCheck = true;
    }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (EnableTiming)
        {
            if (Sound2Check)
            {
                Debug.Log("Congratulations!");
                EnableTiming = false;
            }
            else if (FailCheck)
            {
                Debug.Log("Rip");
                EnableTiming = false;
            }
        }

        FailCheck = false;

    }


    private void OnGUI()
    {
        if (Timer < 10)
        {
            GUI.Label(new Rect(100, 100, 200, 200), "Timer Count = " + Timer);
        }
        else
        {
            GUI.Label(new Rect(100, 100, 200, 200), "See ya");
        }
    }
}