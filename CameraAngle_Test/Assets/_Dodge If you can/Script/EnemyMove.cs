using System.Linq;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float speed = 2.0f;
    public GameObject target;
    public float enemyLimitedTime=3.0f;
    private float enemyLasting;
    public GameObject particle;
    private Rigidbody rb;
    private float theta;
    private int radius;



    // Use this for initialization
    void Start()
    {
    //target = GameObject.Find("Target(Clone)");
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //Target();
        Shot();

        enemyLasting += Time.deltaTime;
        if (enemyLasting>enemyLimitedTime )
        {
            var par = Instantiate(particle);
            par.transform.position = transform.position;
            Destroy(gameObject);
        }
       

	}


    
    void Shot()
    {

        //transform.Translate((player.transform.position - transform.position)*Time.deltaTime*speed //단위 백터를 사용하여야 속도가 일정하다
        Vector3 diff = new Vector3(target.transform.position.x - transform.position.x,0, target.transform.position.z - transform.position.z);
        // new Vector3(player.transform.position.x-transform.position.x,transform.position.y, player.transform.position.z-transform.position.z) ;
        var dir = diff.normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    void Target()
    {
        DestroyAllChildren();
        theta = Random.Range(0, 2 * Mathf.PI);
        radius = Random.Range(0, 99);
        var tr = Instantiate(target, transform);
        tr.transform.position = new Vector3(transform.position.x + radius * Mathf.Sin(theta), 0f, transform.position.z + radius * Mathf.Cos(theta));

    }
    void DestroyAllChildren()
    {
        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);
        }

    }


}
