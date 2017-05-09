using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {
    
    [SerializeField]
    private Animation liftDoor;

    [SerializeField]
    private Animation liftIndic;

    [SerializeField]
    private AudioClip LiftBackgroundSound;

    [SerializeField]
    private AudioClip Ding;

    public void LiftAnimation(string action)
    {
        liftDoor.Play(action);
    }

    public void StartIndicator()
    {
        this.liftIndic.Play("ElevatorUp");
    }

    public void ElevatorSound(bool start)
    {
        if (start == true)
            SoundManager.Instance.PlaySound(this.LiftBackgroundSound);
        else
            SoundManager.Instance.PlaySound(this.Ding);
    }
}
