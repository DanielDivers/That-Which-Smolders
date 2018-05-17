using UnityEngine;
using UnityEditor;

public class ControlScheme : ScriptableObject
{
    public Interactable currentFocus;
    public LayerMask movementMask;
    public Camera cam;

    public Transform transform; 

    public void SetFocus(Interactable newFocus)
    {
        if (newFocus != currentFocus)
        {
            if (currentFocus != null)
            {
                currentFocus.OnDeFocused();
            }

            currentFocus = newFocus;
            //motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    public void RemoveFocus()
    {
        if (currentFocus != null)
        {
            currentFocus.OnDeFocused();
        }

        currentFocus = null;
        //motor.StopFollowingTarget();
    }
}