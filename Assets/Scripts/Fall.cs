using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class Fall : MonoBehaviour
{
    private List<BoxCollider> boxes = new List<BoxCollider>();

    public List<BoxCollider> Boxes
    {
        get
        {
            return this.boxes;
        }
        set
        {
            boxes = value;
        }
    }

    private bool isOn = false;
    
    public bool isFalling = false;

    [SerializeField]
    private float speedFalling = 0.5f;

    [SerializeField]
    private float increaseSpeed = 0.01f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        if (this.isFalling == false)
        {
            this.isOn = false;
            foreach (BoxCollider box in this.boxes)
            {
                if (box.bounds.Contains(Player.instance.feetPositionGuess))
                    this.isOn = true;
            }
            if (this.isOn == false)
                this.isFalling = true;
        }
        if (this.isFalling == true)
        {
            this.speedFalling += increaseSpeed;
            Player.instance.transform.position += this.speedFalling * Vector3.down;
        }
    }
}
