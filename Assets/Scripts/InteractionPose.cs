using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionPose : MonoBehaviour
{

    [SerializeField]
    private HandPoses interactionPose;

    private XRGrabInteractable grabInteractible;

    private void Awake()
    {
        grabInteractible = GetComponent<XRGrabInteractable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        grabInteractible.onSelectEnter.AddListener(OnGrab);
    }

    public void OnGrab(XRBaseInteractor interactor)
    {
        HandVisuals visuals = interactor.GetComponentInChildren<HandVisuals>();
        if(visuals != null)
        {
            visuals.LockPose(interactionPose);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
