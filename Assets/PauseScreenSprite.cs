using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenSprite : MonoBehaviour
{
    [SerializeField] GameObject PauseScreen;
    [SerializeField] GameObject ResumeScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseMode()
    {
        PauseScreen.SetActive(true);
        ResumeScreen.SetActive(false);
    }

    public void ResumeMode()
    {
        PauseScreen.SetActive(false);
        ResumeScreen.SetActive(true);

    }
}
