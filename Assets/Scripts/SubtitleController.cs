using UnityEngine;
using System.Linq;
using TMPro;
using System;
using System.Collections;

public class SubtitleController : MonoBehaviour
{
    [SerializeField] private TextAsset subtitlesTextFile;
    [SerializeField] private Subtitle[] subtitles;
    [SerializeField] private int currentSubtitleIndex;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        text.outlineWidth = .25f;
        text.outlineColor = new Color32(0, 0, 0, 255);
    }

    private void OnValidate()
    {
        subtitles = subtitlesTextFile.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(
            (voiceLine, index) => { 
                index++;
                return new Subtitle{ 
                line = index,
                text = voiceLine
            }; }).ToArray();
    }

    public void NextSubtitle()
    {
        GetComponent<TextMeshProUGUI>().text = subtitles[currentSubtitleIndex].text;
        currentSubtitleIndex++;
    }

    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = " ";
    }
}
