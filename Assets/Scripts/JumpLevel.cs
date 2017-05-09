using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class JumpLevel : AbstractLevelManager {

    [SerializeField]
    private BoxCollider[] boxes;
    private Fall FallingHandler;

    // Use this for initialization
    void Start () {
        this.Init();
        this.FallingHandler = this.GetComponent<Fall>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override IEnumerator BeginExperience()
    {
        FallingHandler.Boxes = new List<BoxCollider>(boxes);
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
