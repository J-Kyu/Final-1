using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Instantiate : MonoBehaviour {

    private float InstantiatingLoadingTime=0.0f;
    public float RestTime=5.0f;
    public int row = 30;
    public int column = 30;
    public int rockNumber = 3;
    public GameObject obstacle;
  
    // Use this for initialization
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {
        InstantiatingLoadingTime += Time.deltaTime;
        if (InstantiatingLoadingTime >= RestTime)
        {

            chess_board();


            InstantiatingLoadingTime = 0.0f;
        }
       
       // Debug.LogFormat("time:{0}",Time.deltaTime);
    }
   

    [ContextMenu("Destory All")]
    void DestroyAllChildren()
    {
        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);
        }

    }

    [ContextMenu("Build Obstacle")]
    void chess_board()
    {
        int[] array = new int[rockNumber];
        DestroyAllChildren();

        for (int i = 1; i <=row; i++)
        {


            for (int r = 0; r < rockNumber; r++)
            {
                array[r] = Random.Range(1, column+1);
                for (int p = 0; p < r; p++)
                {
                    if (array[p] == array[r])
                    {
                        r--;
                        break;
                    }
                }
            }


            //Debug.LogFormat("array:{0},{1},{2}", array[0], array[1], array[2]);
            for (int j = 0; j < rockNumber; j++)
            {
                
                // int x = Random.Range(1, 11); //
                 var newgameObject = Instantiate(obstacle, transform);
                 var obstacle_tr = newgameObject.GetComponentInChildren<Transform>();
                 obstacle_tr.transform.localPosition = new Vector3(array[j], -0.45f, i);
                

            }
        }
    }
}
