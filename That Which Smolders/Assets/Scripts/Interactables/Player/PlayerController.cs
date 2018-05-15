using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum ControlStyle { PointClick, WASD};
    public ControlStyle currentControlStyle;
    public LayerMask movementMask;
    public Interactable currentFocus;

    PlayerControlScheme PlayerControl = new PlayerControlScheme();

    void Start()
    {
        PlayerControl.cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        PlayerControl.movementMask = movementMask;
        PlayerControl.motor = GetComponent<PlayerMotor>();
    }

    void LateUpdate()
    {
        if (currentControlStyle == ControlStyle.PointClick)
        {
            PlayerControl.updatePC();

            currentFocus = PlayerControl.currentFocus;
        }
        else if (currentControlStyle == ControlStyle.WASD)
        {
            PlayerControl.motor.Stop();
            PlayerControl.updateWASD();
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            currentFocus = PlayerControl.currentFocus;
        }
    }
}
