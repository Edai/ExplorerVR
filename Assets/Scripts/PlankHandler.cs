using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Valve.VR.InteractionSystem;

public class PlankHandler : MonoBehaviour
{
    private Hand currentHand;
    
    //-------------------------------------------------
    private void OnHandHoverBegin(Hand hand)
    {
        currentHand = hand;
        InputModule.instance.HoverBegin(gameObject);
        ControllerButtonHints.ShowButtonHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
    }


    //-------------------------------------------------
    private void OnHandHoverEnd(Hand hand)
    {
        InputModule.instance.HoverEnd(gameObject);
        ControllerButtonHints.HideButtonHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        currentHand = null;
    }


    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown())
        {
            InputModule.instance.Submit(gameObject);
            CalibratePlank(hand);
            ControllerButtonHints.HideButtonHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        }
    }

    private void CalibratePlank(Hand hand)
    {
        transform.rotation = hand.transform.rotation;
    }
}