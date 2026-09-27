using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SitOnGrab : MonoBehaviour
{
    public Transform sitPosition;
    public Transform leftPosition;
    public GameObject XRRig;
    
    private bool isSitting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSitting)
        {
            sitting();
        }
    }

    public void sitDown()
    {
        isSitting = true;
        XRRig.transform.rotation = sitPosition.rotation;
    }

    private void sitting()
    {
        XRRig.transform.position = sitPosition.position;
    }

    public void standUp()
    {
        if (isSitting)
        {
            isSitting = false;
            XRRig.transform.position = leftPosition.position;
            XRRig.transform.rotation = leftPosition.rotation;
        }
    }
}
