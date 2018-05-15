using UnityEngine;

public class PlayerControlScheme : MonoBehaviour
{
    public Interactable currentFocus;
    public LayerMask movementMask;
    public Camera cam;
    public PlayerMotor motor;

    public void SetFocus(Interactable newFocus)
    {
        currentFocus = newFocus;
    }

    public void RemoveFocus()
    {
        currentFocus = null;
    }

    //POINT CLICK CONTROL UPDATE
    public void updatePC()
    {
        if (currentFocus != null)
        {
            motor.FocusTarget(currentFocus);
        }
        else motor.RemoveTarget();

        //left click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Move player to location

                motor.MoveToPoint(hit.point);
                //RemoveFocus();
            }
        }

        //right click
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                else SetFocus(null);
            }
        }
    }

    //WASD CONTROL UPDATE
    public void updateWASD()
    {
        //left click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                else SetFocus(null);
            }
        }
    }
}
