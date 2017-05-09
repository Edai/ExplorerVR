//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Collider dangling from the player's head
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof(BoxCollider) )]
	public class BodyCollider : MonoBehaviour
	{
		public Transform head;

		private BoxCollider boxCollider;

		//-------------------------------------------------
		void Awake()
		{
		    boxCollider = GetComponent<BoxCollider>();
		    this.head = Camera.main.transform;
		    Camera.main.transform.parent = this.transform;
		}

	    //-------------------------------------------------
		void FixedUpdate()
		{
			float distanceFromFloor = Vector3.Dot(head.localPosition, Vector3.up);
		    Vector3 newSize = this.boxCollider.size;
		    newSize.y = distanceFromFloor;
		    boxCollider.size = newSize;
			transform.position = head.position - (distanceFromFloor / 2) * Vector3.up;
		}
	}
}
