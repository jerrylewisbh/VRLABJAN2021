using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private static readonly int ControllerSelectHash = Animator.StringToHash("ControllerSelectValue");

    protected Animator animator;



    [SerializeField]
    private InputActionProperty flex;


    private void Update()
    {
        SetAnimatorInputValue(flex.action, ControllerSelectHash);
    }

    private void SetAnimatorInputValue(InputAction action, int hashAnimator)
    {
        if(action != null)
        {
            animator.SetFloat(hashAnimator, action.ReadValue<float>());
        }
    }


    protected void Awake()
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
