using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("EXIT BUTTON CLICKED!");
        Application.Quit();
    }
}
