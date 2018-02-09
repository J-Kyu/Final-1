using UnityEngine;

public class Move : MonoBehaviour {
    public float speed = 1.0f;
	public float handle_speed=3.0f;
	private Rigidbody rb;
	public float jumpheight=1.0f;
    public float gravity = -0.98f;
    public float reverse_speed;


   

	// Use this for initialization
	private void Start () {
        //reverse_speed = speed;
		rb = GetComponent<Rigidbody>();

	}


    private void Update()
    {
        reverse_speed = speed;

        // rb.velocity = transform.up * gravity;
          
        if (Input.GetKey(KeyCode.UpArrow))
        {   
            rb.velocity = (transform.forward*speed+transform.TransformDirection(0,1,0) *(gravity));//in air the graivity works as (-speed/80)

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            

                if(rb.velocity.x<=0 ){
                rb.velocity = (-transform.forward * speed/2);//going back makes half speed slow   
             }

          
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * handle_speed, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * handle_speed, Space.World);
        }

       //In air, i should probably use layer or tag to assign the velocity declining to 0.

        Debug.LogFormat("{0}", rb.velocity.x);

        if (Input.GetKey(KeyCode.R)){
            transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        Vector3 movedPosition = transform.position;

        if (movedPosition.x > 24)
        {
            movedPosition.x = 24;
        }


        if (movedPosition.x < -24)
        {
            movedPosition.x = -24;
        }

        if (movedPosition.z > 24)
        {
            movedPosition.z = 24;
        }                                   //movedPosition.z=Mathf.Clamp(movedPosition.z,-50,+50);
        if (movedPosition.z < -24)
        {
            movedPosition.z = -24;
        }
        transform.position = movedPosition;

        
    
    }

    private void OnTriggerEnter(Collider other)
    {
       


                if (other.CompareTag("Untagged"))
                {
                    rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                    speed = 0.0f;
                    reverse_speed = 0.0f;
                    rb.velocity = (transform.TransformDirection(0, 1, 0) * (gravity));//in air the graivity works as (-speed/80)

                }
            }
        }

    


