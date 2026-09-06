using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] private GameObject defaultLever;
    [SerializeField] private GameObject pulledLever;

    public void PullLever()
    {
        defaultLever.SetActive(false);
        pulledLever.SetActive(true);
    }

    public void ResetLever()
    {
        pulledLever.SetActive(false);
        defaultLever.SetActive(true);
    }
}
