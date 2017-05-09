using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour {

    [SerializeField]
    private AbstractLevelManager levelManager;

    void OnTriggerEnter(Collider other)
    {
        levelManager.StartExperience();
    }
}
