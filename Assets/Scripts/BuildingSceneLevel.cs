using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

using Valve.VR.InteractionSystem;

public class BuildingSceneLevel : AbstractLevelManager
{
    [SerializeField]
    private BoxCollider[] boxes;
    
    [SerializeField]
    private Fall FallingHandler;

    [SerializeField]
    private Lift liftObject;

    void Start()
    {
        this.Init();               
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey("space"))
        {
            if (this.playing == false) StartExperience();
            else this.StopExperience();
        }
#endif
    }

    public override IEnumerator BeginExperience()
    {
        yield return new WaitForSeconds(1f);
        liftObject.LiftAnimation("Close");
        this.liftObject.ElevatorSound(true);
        liftObject.StartIndicator();
        yield return new WaitForSeconds(16f);
        FallingHandler.Boxes = new List<BoxCollider>(boxes);
        for (int i = 0; i < objectsToActivate.Count; i++)
            objectsToActivate[i].SetActive(true);
        this.liftObject.ElevatorSound(false);
        yield return new WaitForSeconds(1f);
        this.InitSound();
        liftObject.LiftAnimation("Open");
        Destroy(liftObject.gameObject, 3);
        FallingHandler.enabled = true;
        yield return null;
    }

    public override IEnumerator EndExperience(bool loose = false)
    {
        FallingHandler.isFalling = false;
        Destroy(FallingHandler);
        GameManager.Instance.ChangeNextEnvironment(loose);
        Player.instance.transform.position = new Vector3(0.0f, 0.0f);
        yield return null;
    }
}