using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class DialogueTimer : MonoBehaviour
{
    public static DialogueTimer Instance { get; private set; }

    [SerializeField] private PlayableDirector AudioDir;
    [SerializeField] private PlayableDirector SpriteDir;
    [SerializeField] private float TimerCheck;
    [SerializeField] private Image QTEIndi;
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject GameOverScreen;

    public bool WinCheck;
    public bool EnableTiming = false;
    public bool FailCheck = false;

    float Timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void StartingClick()
    {
        WinCheck = true;
        Debug.Log("Clicked!");
    }

    public void StartButton()
    {
        AudioDir.Play();
        SpriteDir.Play();
        PauseScreen.SetActive(false);
    }


    public void EnableTime(int emotions)
    {
        EnableTiming = true;
        QTEIndi.enabled = true;
        FindObjectOfType<SoundButtonManager>().SetInputTakeable(IntToEnum(emotions));
    }

    public EnumSoundType IntToEnum(int num)
    {
        return (EnumSoundType)num;
    }

    public void FailFlag()
    {
        FailCheck = true;
        QTEIndi.enabled = false;
    }

    public void DirectorPause()
    {
        AudioDir.Pause();
        SpriteDir.Pause();
        PauseScreen.SetActive(true);
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
            if (WinCheck)
            {
                Debug.Log("Congratulations");
                FindObjectOfType<ViewerCount>().ChangeViewerCount(false);
                EnableTiming = false;
                WinCheck = false;
            }
            else if (FailCheck)
            {
                Debug.Log("Rip");
                EnableTiming = false;
                FindObjectOfType<ViewerCount>().ChangeViewerCount(true);

            }
        }

        FailCheck = false;
    }


    //private void OnGUI()
    //{
    //    if (Timer < 10)
    //    {
    //        GUI.Label(new Rect(100, 100, 200, 200), "Timer Count = " + Timer);
    //    }
    //    else
    //    {
    //        GUI.Label(new Rect(100, 100, 200, 200), "See ya");
    //    }
    //}
}