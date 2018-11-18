using UnityEngine;

public class InstantiateEnemy : MonoBehaviour {

    private float enemyLastingTime;
   

    private float enemyRespawnTime=10f;
    public GameObject enemyPrefabs;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        enemyLastingTime += Time.deltaTime;
        if (enemyLastingTime > enemyRespawnTime) {
            var enemy = Instantiate(enemyPrefabs,transform);
            enemy.transform.localScale = new Vector3(1,1,1)/20;
            //enemy.transform.position=ship.transform.position;
        
        
        enemyLastingTime = 0f;
        }
    }
}