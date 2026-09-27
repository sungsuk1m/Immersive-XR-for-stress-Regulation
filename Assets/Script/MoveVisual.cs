using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class MoveVisual : MonoBehaviour
{
    public Transform XRRig = null;
    public GameObject visualObject = null;

    public void setPosition()
    {
        visualObject.transform.position = XRRig.transform.position;
        visualObject.transform.rotation = XRRig.rotation;
        visualObject.transform.Rotate(0, 45, 0);
        visualObject.transform.Translate(Vector3.forward * 0.8f);
        visualObject.transform.Translate(Vector3.up * 1.2f);
    }
}
