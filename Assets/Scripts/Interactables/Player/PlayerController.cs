using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum ControlStyle { PointClick, WASD};
    public ControlStyle currentControlStyle;
    public LayerMask movementMask;
    public Interactable currentFocus;

    PlayerPointClickControlScheme PointClickControl = new PlayerPointClickControlScheme();
    PlayerWASDControlScheme WASDControl = new PlayerWASDControlScheme();

    private void Start()
    {
        PointClickControl.cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        PointClickControl.movementMask = movementMask;
        PointClickControl.motor = GetComponent<PlayerMotor>();

        WASDControl.cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        WASDControl.movementMask = movementMask;
    }

    void LateUpdate()
    {
        if (currentControlStyle == ControlStyle.PointClick)
        {
            PointClickControl.update();

            currentFocus = PointClickControl.currentFocus;
        }
        else if (currentControlStyle == ControlStyle.WASD)
        {
            WASDControl.update();
            currentFocus = WASDControl.currentFocus;
        }
    }
}
