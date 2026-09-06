using UnityEngine;

public class RetryButton : MonoBehaviour
{
    [SerializeField] GameController gameController;

    public void OnMouseDown()
    {
        gameController.RetryGame();
    }
}
