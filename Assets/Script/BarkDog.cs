using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarkDog : MonoBehaviour
{
    public Transform rightHand;
    public Vector3 rotationRangeMin;
    public Vector3 rotationRangeMax;
    public Animator animator;

    private bool isInside = false;

    [Serializable] public class BarkEvent : UnityEvent<MonoBehaviour> { }

    public BarkEvent OnBegin = new BarkEvent();
    public BarkEvent OnEnd = new BarkEvent();

    void Update()
    {
        if (isInside)
        {
            Vector3 rightHandRotation = rightHand.eulerAngles;
            if (isRotationWithinRange(rightHandRotation))
            {
                Bark();
            }
        }
    }

    bool isRotationWithinRange(Vector3 rotation)
    {
        if ((rotation.x >= rotationRangeMin.x && rotation.x <= rotationRangeMax.x)
            && (rotation.y >= rotationRangeMin.y && rotation.y <= rotationRangeMax.y)
            && (rotation.z >= rotationRangeMin.z && rotation.z <= rotationRangeMax.z))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            isInside = false;
            OnEnd.Invoke(this);
            animator.SetInteger("AnimationID", 1);
        }
    }
    private void Bark()
    {
        OnBegin.Invoke(this);
        animator.SetInteger("AnimationID", 6);
    }
}
