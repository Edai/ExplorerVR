using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class GroundStop : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> IgnoredList;

    void OnTriggerEnter(Collider c)
    {
        foreach (var s in this.IgnoredList)
        {
            if (c.name == s.name) return;
        }
        GameManager.Instance.CurrentLevelManager.StopExperience(true);
    }
}
