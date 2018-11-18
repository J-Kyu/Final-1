using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    public AudioSource audioSource;
    public PlayerHp playerHp;
    public GameObject particle;
    // Use this for initialization
    void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    public void PlaySound()
    {
        audioSource.Play();
        // Debug.LogFormat("wow");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            var par = Instantiate(particle);
            par.transform.position = transform.position;
            playerHp.playerLastingTime=0.0f;
            playerHp.DamageHp(1);
            PlaySound();


        }
    }
}
