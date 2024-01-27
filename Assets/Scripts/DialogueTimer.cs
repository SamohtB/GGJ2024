using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class DialogueTimer : MonoBehaviour
{
    public static DialogueTimer Instance { get; private set; }

    [SerializeField] private Button Sound1;
    [SerializeField] private Button Sound2;
    [SerializeField] private PlayableDirector AudioDir;
 
    private bool Sound2Check;
    public bool EnableTiming = false;

    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Sound2.onClick.AddListener(Sound2Click);
    }

    private void Sound2Click()
    {
        Sound2Check = true;
        Debug.Log("Clicked!");
    }

    public void StartButton()
    {
        AudioDir.Play();
    }

    public void EnableTime()
    {
        EnableTiming = true;
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
        if (EnableTiming)
        {
            Timer += Time.deltaTime;
            if (Sound2Check) 
            { 
                Debug.Log("Congratulations!");  
            }
            else if (Timer > 3.0f)
            {
                Debug.Log("YOu suck");
                EnableTiming = false;
            }
        }
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
