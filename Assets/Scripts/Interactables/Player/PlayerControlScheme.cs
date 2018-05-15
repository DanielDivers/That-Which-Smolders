using UnityEngine;

public class PlayerControlScheme : MonoBehaviour
{
    public Interactable currentFocus;
    public LayerMask movementMask;
    public Camera cam;

    public void SetFocus(Interactable newFocus)
    {
        currentFocus = newFocus;
    }

    public void RemoveFocus()
    {
        currentFocus = null;
    }
}
