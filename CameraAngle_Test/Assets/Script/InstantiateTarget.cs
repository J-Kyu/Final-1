
using System.Linq;
using UnityEngine;

public class InstantiateTarget : MonoBehaviour {

    public GameObject target;
    private float radius;
    private float theta;
    private float targetLastingTime;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        targetLastingTime += Time.deltaTime;

            
        if (targetLastingTime >=10)
        {

           Target();
            targetLastingTime = 0;
            }
	}



    void Target()
    {
        DestroyAllChildren();
        theta = Random.Range(0,2*Mathf.PI);
        radius = Random.Range(0, 99);
        var tr = Instantiate(target, transform);
        tr.transform.position = new Vector3(transform.position.x + radius * Mathf.Sin(theta), 0f, transform.position.z + radius * Mathf.Cos(theta));

    }
    [ContextMenu("Destory All")]
    void DestroyAllChildren()
    {
        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);
        }

    }
}
