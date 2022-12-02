using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandedGrabSkewer : XRGrabInteractable
{
    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();
    private XRBaseInteractor secondInteractor;
    private Quaternion attachInitialRotation;
    public enum TwoHandRotationType {None,First,Second};
    public TwoHandRotationType twoHandRotationType;
    public bool snapToSecondHand = true;
    private Quaternion initialRotationOffset;
    public bool bothHandsOnGun;
    public Skewer skewerScript;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in secondHandGrabPoints)
        {
            item.onSelectEntered.AddListener(OnSecondHandGrab);
            item.onSelectExited.AddListener(OnSecondHandRelease);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
         if(secondInteractor && selectingInteractor)
         {
             if(snapToSecondHand)
             {
                 selectingInteractor.attachTransform.rotation = GetTwoHandRotation();
             }
             else
             {
                 selectingInteractor.attachTransform.rotation = GetTwoHandRotation() * initialRotationOffset;
             }
         }
         base.ProcessInteractable(updatePhase);
    }

    private Quaternion GetTwoHandRotation()
    {
        Quaternion targetRotation;
        if(twoHandRotationType == TwoHandRotationType.None)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
        }
        else if(twoHandRotationType == TwoHandRotationType.First)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.attachTransform.up);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, secondInteractor.attachTransform.up);
        }

        return targetRotation;
    }
    
    public void OnSecondHandGrab(XRBaseInteractor interactor)
    {
        secondInteractor = interactor;
        initialRotationOffset = Quaternion.Inverse(GetTwoHandRotation()) * selectingInteractor.attachTransform.rotation;
        bothHandsOnGun = true;
        skewerScript.secondaryHand = interactor.gameObject.GetComponent<XRDirectInteractor>();
    }

    public void OnSecondHandRelease(XRBaseInteractor interactor)
    {
        selectingInteractor.attachTransform.localRotation = attachInitialRotation;
        secondInteractor = null;
        bothHandsOnGun = false;
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        attachInitialRotation = interactor.attachTransform.localRotation;
        skewerScript.primaryHand = interactor.gameObject.GetComponent<XRDirectInteractor>();
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        secondInteractor = null;
        interactor.attachTransform.localRotation = attachInitialRotation;
    }

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        bool isalreadygrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isalreadygrabbed;
    }
}
