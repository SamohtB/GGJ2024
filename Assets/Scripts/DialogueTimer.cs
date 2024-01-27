using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTimer : MonoBehaviour
{
    public static DialogueTimer Instance { get; private set; }

    [SerializeField] private Button Sound1;
    [SerializeField] private Button Sound2;
    [SerializeField] private AudioSource WaterS1;
 
    private bool Sound2Check;

    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Sound2.onClick.AddListener(Sound1Click);
        WaterS1.Play();
    }

    private void Sound1Click()
    {
        Sound2Check = true;
        Debug.Log("Clicked!");
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

        if (Timer > 1.4f & Timer < 3.0f)
        {
            if (Sound2Check) { Debug.Log("Congratulations!");  }
        }
        else if (Timer > 3.0f)
        {
            if (!Sound2Check) { Debug.Log("You suck"); }
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
