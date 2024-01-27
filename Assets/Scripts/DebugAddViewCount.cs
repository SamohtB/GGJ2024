using UnityEngine;

public class DebugAddViewCount : MonoBehaviour
{
    [SerializeField] private ViewerCount counter;

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_LOSE, DebugLogEndGame);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_GAME_LOSE);
    }

    public void AddViews()
    {
        counter.ChangeViewerCount(true);
    }

    public void DebugLogEndGame()
    {
        Debug.Log("PLAYER LOSE - GAME END");
    }
}
