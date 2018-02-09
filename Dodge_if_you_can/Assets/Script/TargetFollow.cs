using UnityEngine;

public class TargetFollow : MonoBehaviour {

	public Transform target;
	public float theta;


	void Update(){
		//if (target.rotation.y <= 0.7017068 && target.rotation.y >= -0.7071068) 
		transform.position = (new Vector3 (target.position.x + (-3) * Mathf.Sin (target.eulerAngles.y*(Mathf.PI/180) ), 0.5f+target.position.y ,target.position.z + (-3) * Mathf.Cos (target.eulerAngles.y*(Mathf.PI/180) )));

        //Debug.LogFormat ("pass:{0}", target.eulerAngles.y);

        //else 
        //transform.position =(-1)*(new Vector3 ((target.position.x + (-3) * Mathf.Sin (theta)), 1.0f, (target.position.z + (-3) * Mathf.Cos (theta))));
        //	Debug.LogFormat("---------------------------");

        transform.rotation = Quaternion.Euler(15.0f, target.eulerAngles.y, 0.0f);
            //target.rotation;
		//Debug.LogFormat ("{0}",transform.rotation.y);
		//transform.LookAt(target);
	}
}
