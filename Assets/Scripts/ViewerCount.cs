using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewerCount : MonoBehaviour
{
    [SerializeField] private int currentViewerCount = 500;
    [SerializeField] private int penalty = 170;
    [SerializeField] private int reward = 80;
    [SerializeField] private TextMeshProUGUI viewCountText;

    private void Start()
    {
        viewCountText.text = currentViewerCount.ToString();
    }

    public void ChangeViewerCount(bool isPenalty)
    {
        if (isPenalty) 
        {
            AddViewerCount(-penalty);
        }
        else
        {
            AddViewerCount(reward);
        }
    }

    private void AddViewerCount(int additionalViewers)
    {
        currentViewerCount += additionalViewers;
        viewCountText.text = currentViewerCount.ToString();

        if(currentViewerCount <= 0)
        {
            //Lose Condition
            SceneManager.LoadScene("GameOverLose");
            EventBroadcaster.Instance.PostEvent(EventNames.ON_GAME_LOSE);
        }
    }
}
