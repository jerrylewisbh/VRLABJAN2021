using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HandPoses
{
    NoPose,
    SoftGrab = 20,
    MediumGrab = 21,
    HardGrab = 22,
    SoftPinch = 30,
    MediumPinch = 31,
    HardPinch = 32
}

public class HandVisuals : MonoBehaviour
{

    private static readonly int LockPoseHash = Animator.StringToHash("LockedPose");

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        //LockPose(HandPoses.MediumGrab);
    }


    public void LockPose(HandPoses newPose)
    {
        animator.SetInteger(LockPoseHash, (int)newPose);
    }

    
}
