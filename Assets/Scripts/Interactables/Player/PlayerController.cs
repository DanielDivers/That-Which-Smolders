using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum ControlStyle { PointClick, WASD};
    public ControlStyle currentControlStyle;
    public LayerMask movementMask;

    PointClickControl pcControl;
    WASDControl wasdControl;

    void Start()
    {
        pcControl = new PointClickControl();
        wasdControl = new WASDControl();

        pcControl.cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        pcControl.motor = GetComponent<PlayerMotor>();
        pcControl.movementMask = movementMask;
        pcControl.transform = transform;

        wasdControl.cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        wasdControl.movementMask = movementMask;
        wasdControl.transform = transform;
    }

    void LateUpdate()
    {
        if (currentControlStyle == ControlStyle.PointClick)
        {
            pcControl.updatePC();
        }

        else if (currentControlStyle == ControlStyle.WASD)
        {
            pcControl.motor.Stop();
            wasdControl.updateWASD();   
        }
    }
}
