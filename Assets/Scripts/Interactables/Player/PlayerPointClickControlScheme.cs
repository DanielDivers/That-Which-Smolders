using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerPointClickControlScheme : PlayerControlScheme
{
    public PlayerMotor motor;

    //our own update loop so we can call when we want
    public void update()
    {
        if (currentFocus != null)
        {
            motor.FocusTarget(currentFocus);
        }else motor.RemoveTarget();

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
}
