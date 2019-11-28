﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour {
	public int segments;
	public float xradius;
	public float yradius;
	LineRenderer _lineRenderer;

	[ContextMenu ("Create Points")]
	void CreatePoints ()
	{
		_lineRenderer = gameObject.GetComponent<LineRenderer>();
		_lineRenderer.SetVertexCount (segments + 1);

		float x;
		float y;
		float z = 0f;
	
		float angle = 20f;

		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
			y = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius;

			_lineRenderer.SetPosition (i,new Vector3(x,y,z) );

			angle += (360f / segments);
		}
	}
}