using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PetDog : MonoBehaviour
{
    public Animator animator;
    private int sitCounter = 0;
    [Serializable] public class PetEvent : UnityEvent<MonoBehaviour> { }

    public PetEvent OnBegin = new PetEvent();
    public PetEvent OnEnd = new PetEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            animator.SetInteger("AnimationID", 7);
            OnBegin.Invoke(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            animator.SetInteger("AnimationID", 1);
            OnEnd.Invoke(this);
        }
    }


}
