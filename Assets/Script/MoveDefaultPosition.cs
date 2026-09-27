using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDefaultPosition : MonoBehaviour
{
    public Transform defaultPosotion = null;
    public GameObject targetObject = null;

    public void moveDefaultPosition()
    {
        targetObject.transform.position = defaultPosotion.position;
        targetObject.transform.rotation = defaultPosotion.rotation;
    }
}
