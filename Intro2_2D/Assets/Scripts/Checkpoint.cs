using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col)
	{
		FindObjectOfType<CheckpointManager>().SetCheckPointPosition(transform.position);
	}
}
