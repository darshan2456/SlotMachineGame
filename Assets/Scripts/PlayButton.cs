using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] PopupController popupController;

    private void OnMouseDown()
    {
        popupController.Play();
    }
}
