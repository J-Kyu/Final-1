using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour {
    public float radius;
    public float enemyLastingTime=1.0f;
    public GameObject player;
    private float theta;
    private float lastLogTime;
    public GameObject enemyPrefabs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        theta= Random.Range(0, 2 * Mathf.PI);
        if (Time.time - lastLogTime > enemyLastingTime)
        {
            var enemy = Instantiate(enemyPrefabs,transform);
            var tr= enemy.transform;
            tr.position = new Vector3(player.transform.position.x+radius * Mathf.Sin(theta), 0f,player.transform.position.z+ radius * Mathf.Cos(theta));
            
            lastLogTime = Time.time;
        }
        
		
	}
}
