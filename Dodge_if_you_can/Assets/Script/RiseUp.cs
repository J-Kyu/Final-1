using UnityEngine;
/*
 * after[Instantiate], time of beblow is (seconds) 
 *      shakingTime=a;
 *      RockUp=1;
 *      LastingTime=10;
 *      RockDown=1;
 * 
 * On [Instantiate.cs] give value on "restime" which is sum of above time.
 * If you sum of above time does not result in "restime", error might be consequence. 
 * 
 * 
 *
 */





public class RiseUp : MonoBehaviour {
    private float shakingLoadingTime;
    public float shakingTime=2.0f;
    private Quaternion originRotation;
    public float shake_intensity = 0.01f;       //origin value is 0.01f
    public float shake_decay = 0.002f;          //origin value is 0.002f
    public float shake_power = 0.2f;            //origin value is 0.2f
    // Use this for initialization
    void Start () {
        originRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        shakingLoadingTime += Time.deltaTime;
        //Debug.LogFormat("time:{0}", Time.time);
        if (shakingLoadingTime < shakingTime)
        {

            EarthQuake();
            

        }
        if (shakingLoadingTime > shakingTime && shakingLoadingTime<shakingTime+1)
        {
            RockUp();
          
        }
        if (shakingLoadingTime>shakingTime+1+10)
        RockDown();

	}

    void RockDown(){
        transform.Translate(new Vector3(0, -1 * Time.deltaTime, 0));
    }

    void RockUp(){
        transform.Translate(new Vector3(0, 1 * Time.deltaTime, 0));
    }

    void EarthQuake()
    {

        transform.rotation = new Quaternion(originRotation.x + Random.Range(-shake_intensity, shake_intensity) * shake_power, originRotation.y + Random.Range(-shake_intensity, shake_intensity) * shake_power, originRotation.z + Random.Range(-shake_intensity, shake_intensity) * shake_power, originRotation.w + Random.Range(-shake_intensity, shake_intensity) * shake_power);
        shake_intensity -= shake_decay;
    }

   
}
