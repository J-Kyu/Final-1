using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    [ContextMenu("Rnadom")]
    void rand()
    {
        int[] array = new int[3];

        for (int r = 0; r < 3; r++)
        {
            array[r] = Random.Range(1, 11);
            for (int p = 0; p < r; p++)
            {
                if (array[p] == array[r])
                {
                    r--;
                    break;
                }
            }
        }


        Debug.LogFormat("array:{0},{1},{2}", array[0], array[1], array[2]);
    }
}
