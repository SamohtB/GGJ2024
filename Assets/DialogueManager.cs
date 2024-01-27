using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI DialogueText;
    [SerializeField] private GameObject Button1;
    [SerializeField] private GameObject Button2;

    private bool WaitingForButton;
    private int SoundButton;
    private bool Butt1Clicked;
    private bool Butt2Clicked;
    [SerializeField] private int CorrectButt;
    private int CountingDown;
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


    // Start is called before the first frame update
    void Start()
    {

    }

    public void Butt1Check()
    {
        Butt1Clicked = true;
    }

    public void Butt2Check()
    {
        Butt2Clicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!WaitingForButton)
        {
            SoundButton = Random.Range(0, 1);
            CountingDown = 1;
            StartCoroutine(Countdown());
            if (SoundButton == 0)
            {
                WaitingForButton = true;
                Button1.GetComponent<TextMeshProUGUI>().text = "Press Me!";
            }

            if (SoundButton == 1)
            {
                WaitingForButton = true;
                Button2.GetComponent<TextMeshProUGUI>().text = "Press Me!";
            }
        }


        if (SoundButton == 0)
        {
           if (Butt1Clicked)
            {
                CorrectButt = 1;
                StartCoroutine(ButtonPressing());
            }
            else
            {
                CorrectButt = 2;
                StartCoroutine(ButtonPressing());
            }
        }

        if (SoundButton == 1)
        {
            if (Butt2Clicked)
            {
                CorrectButt = 1;
                StartCoroutine(ButtonPressing());
            }
            else
            {
                CorrectButt = 2;
                StartCoroutine(ButtonPressing());
            }
        }

    }


    IEnumerator ButtonPressing()
    {
        SoundButton = 3;
        if (CorrectButt == 1)
        {
            CountingDown = 2;
            DialogueText.text = "You are winner";
            yield return new WaitForSeconds(1.5f);
            CorrectButt = 0;
            DialogueText.text = "";
            Button1.GetComponent<TextMeshProUGUI>().text = "";
            Button2.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForButton = false;
            CountingDown = 1;
        }

        if (CorrectButt == 2)
        {
            CountingDown = 2;
            DialogueText.text = "You are sad";
            yield return new WaitForSeconds(1.5f);
            CorrectButt = 0;
            DialogueText.text = "";
            Button1.GetComponent<TextMeshProUGUI>().text = "";
            Button2.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForButton = false;
            CountingDown = 1;
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1.5f);
        CountingDown = 2;
        DialogueText.text = "You are sad";
        yield return new WaitForSeconds(1.5f);
        CorrectButt = 0;
        DialogueText.text = "";
        Button1.GetComponent<TextMeshProUGUI>().text = "";
        Button2.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(1.5f);
        WaitingForButton = false;
        CountingDown = 1;
    }

}

