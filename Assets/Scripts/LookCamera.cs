using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class LookCamera : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.LookRotation(transform.position - Player.instance.hmdTransform.position);  
    }
}
