using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionPose : MonoBehaviour
{

    [SerializeField]
    private HandPoses interactionPose;
    
    private XRBaseInteractable grabInteractible;

    [SerializeField]
    private bool hideController = false;

    private void Awake()
    {
        grabInteractible = GetComponent<XRBaseInteractable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        grabInteractible.onSelectEnter.AddListener(OnGrab);
        grabInteractible.onSelectExit.AddListener(OnRelease);
    }

    public void OnGrab(XRBaseInteractor interactor)
    {
        interactor.GetComponent<XRBaseController>().hideControllerModel = hideController;
        ChangePose(interactionPose, interactor);
    }

    public void OnRelease(XRBaseInteractor interactor)
    {
        interactor.GetComponent<XRBaseController>().hideControllerModel = false;
        ChangePose(HandPoses.NoPose, interactor);
    }

    private void ChangePose( HandPoses newPose, XRBaseInteractor interactor)
    {
        HandVisuals visuals = interactor.GetComponentInChildren<HandVisuals>();
        if (visuals != null)
        {
            visuals.LockPose(newPose);
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
