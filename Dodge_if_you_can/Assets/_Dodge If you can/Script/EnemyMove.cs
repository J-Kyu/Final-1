using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float speed = 2.0f;
    public GameObject player;
    public float enemyLimitedTime=3.0f;
    private float enemyLasting;
    public GameObject particle;
    
   
	// Use this for initialization
	void Start () {
        player= GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Translate((player.transform.position - transform.position)*Time.deltaTime*speed //단위 백터를 사용하여야 속도가 일정하다
        var diff = player.transform.position - transform.position;
        var dir = diff.normalized;              //단위 백터
        transform.Translate(dir * speed * Time.deltaTime);
        //Debug.LogFormat("{0}", Time.time);

        enemyLasting += Time.deltaTime;
        if (enemyLasting>enemyLimitedTime )
        {
            var par = Instantiate(particle);
            par.transform.position = transform.position;
            Destroy(gameObject);
        }
       

	}
    
}
