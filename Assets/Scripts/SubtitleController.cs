using UnityEngine;
using System.Linq;
using TMPro;
using System;
using System.Collections;

public class SubtitleController : MonoBehaviour
{
    [SerializeField] private TextAsset subtitlesTextFile;
    [SerializeField] private string voiceLinesFolderPath;
    [SerializeField] private Subtitle[] subtitles;
    [SerializeField] private int currentSubtitleIndex;

    private void OnValidate()
    {
        subtitles = subtitlesTextFile.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(
            (voiceLine, index) => { 
                index++;
                return new Subtitle{ 
                line = index,
                text = voiceLine,
                duration = GetVoiceLineDuration(index)
            }; }).ToArray();
    }

    public float GetVoiceLineDuration(int line)
    {
        string path = $"{voiceLinesFolderPath}/line {line}";
        var clip = Resources.Load<AudioClip>(path);

        if(clip == null) { return 0; }

        return clip.length;
    }

    private IEnumerator ShowSubtitles()
    {
        while(currentSubtitleIndex < subtitles.Length)
        { 
            GetComponent<TextMeshProUGUI>().text = subtitles[currentSubtitleIndex].text;
            yield return new WaitForSeconds(subtitles[currentSubtitleIndex].duration);
            currentSubtitleIndex++;
        }
    }

    void Start()
    {
        StartCoroutine(ShowSubtitles());
    }
}
