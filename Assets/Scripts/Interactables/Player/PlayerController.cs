using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum ControlStyle { PointClick, WASD};
    public ControlStyle currentControlStyle;

    public Interactable currentFocus;
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        motor = GetComponent<PlayerMotor>();
    }

    void LateUpdate()
    {
        if (currentControlStyle == ControlStyle.PointClick)
        {
            updatePC();
        }

        else if (currentControlStyle == ControlStyle.WASD)
        {
            motor.Stop();
            updateWASD();

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, 0.1f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -0.1f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-0.1f, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(0.1f, 0, 0);
            }
        }
    }

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

    void RemoveFocus()
    {
        if (currentFocus != null)
        {
            currentFocus.OnDeFocused();
        }

        currentFocus = null;
        //motor.StopFollowingTarget();
    }

    //POINT CLICK CONTROL UPDATE
    void updatePC()
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
                RemoveFocus();
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
                //else SetFocus(null);
            }
        }
    }

    //WASD CONTROL UPDATE
    void updateWASD()
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
                //else SetFocus(null);
            }
        }
    }
}
