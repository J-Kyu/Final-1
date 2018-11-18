using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    public float speed=3.0f;
    public GameObject enemy;
    public DirPad dirpad;
  
    // Use this for initialization
    void Start () {
        enemy = GameObject.Find("CapsuleEnemy");
   
	}
	
	// Update is called once per frame
	void Update () {

        if (dirpad.dragging)
        {
            var dn = dirpad.dir.normalized * Time.deltaTime * speed;
            transform.Translate(new Vector3(dn.x, 0, dn.y));
        }


        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h * Time.deltaTime * speed, 0.0f, v * Time.deltaTime * speed));
        Vector3 movedPosition = transform.position;

        if (movedPosition.x > 49)
        {
            movedPosition.x=49;    
        }


        if (movedPosition.x <-49)
        {
            movedPosition.x = -49;
        }

        if (movedPosition.z > 49)
        {
            movedPosition.z = 49;
        }                                   //movedPosition.z=Mathf.Clamp(movedPosition.z,-50,+50);
        if (movedPosition.z < -49)
        {
            movedPosition.z = -49;
        }
        transform.position = movedPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == enemy)
        {
            DestroyImmediate(enemy);
        }
    }
}
