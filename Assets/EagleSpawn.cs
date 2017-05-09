using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class EagleSpawn : MonoBehaviour {

    [SerializeField]
    private GameObject Eagle;

    private BoxCollider box;

    void Start()
    {
        this.box = this.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (box.bounds.Contains(Player.instance.feetPositionGuess))
        {
            this.Eagle.active = true;
            Destroy(Eagle, 4);
            Destroy(this.gameObject);
        }
    }
}
