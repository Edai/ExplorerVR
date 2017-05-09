using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class EndPoint : MonoBehaviour {

    [SerializeField]
    private AbstractLevelManager levelManager;

    [SerializeField]
    private bool LoosingPoint = false;

    private BoxCollider box;

    void Start()
    {
        this.box = this.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (box.bounds.Contains(Player.instance.feetPositionGuess))
            levelManager.StopExperience(LoosingPoint);
#if UNITY_EDITOR
        if (Input.GetKey("space"))
            levelManager.StopExperience();
#endif
    }
}
