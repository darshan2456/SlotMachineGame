using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private ReelController[] reels;

    public void HidePopup()
    {
        gameObject.SetActive(false);
    }

    public void Play()
    {
        gameObject.SetActive(false);
        foreach (ReelController reel in reels)
        {
            reel.startSpin();
        }
    }
}
