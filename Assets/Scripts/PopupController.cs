using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private LeverController leverController;
    [SerializeField] private ReelController[] reels;


    public void Play()
    {
        gameObject.SetActive(false);

        leverController.Invoke(nameof(LeverController.PullLever), 1f);

        foreach (ReelController reel in reels)
        {
            reel.Invoke(nameof(ReelController.startSpin), 1f);
        }
    }
}
