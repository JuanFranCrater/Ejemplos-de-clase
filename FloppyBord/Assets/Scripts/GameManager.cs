using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> birdsList;
	
	void Update ()
    {
        CheckPositions();
	}

    private void CheckPositions()
    {
        birdsList.Sort((p1, p2) => p1.transform.position.x.CompareTo(p2.transform.position.x));
        for(int i = 0; i < birdsList.Count; i++)
        {
            birdsList[i].GetComponent<BirdStats>().SetPosition(birdsList.Count - i);
        }
    }
}
