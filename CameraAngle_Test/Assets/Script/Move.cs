using UnityEngine;

public class Move : MonoBehaviour {
    public float acel = 800.0f;
	public float handle_speed=3.0f;
	private Rigidbody rb;
	public float jumpheight=1.0f;
    public float gravity = -0.98f;
    public float reverse_speed;
    public float radius=100;




    // Use this for initialization
    private void Start () {
        //reverse_speed = speed;
		rb = GetComponent<Rigidbody>();

	}

   public void foward()
    {
        //speed = 10.0f;
        // rb.velocity = (transform.forward * speed);// + transform.TransformDirection(0, 1, 0) * (gravity));//in air the graivity works as (-speed/80)
        rb.AddForce((transform.forward * acel*Time.deltaTime));
        Debug.LogFormat("SPeed.x:{0}",rb.velocity);
    }
   public void   backward()
    {
        rb.AddForce((-transform.forward * (acel-100) * Time.deltaTime));



    }
   public void left()
    {
        transform.Rotate(new Vector3(0, -1 * Time.deltaTime * handle_speed, 0), Space.World );
    }
   public void right()
    {
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * handle_speed, Space.World);
    }
    private void Update()
    {

      
  //  Debug.LogFormat("Speed:{0}",rb.velocity.magnitude);
        // rb.velocity = transform.up * gravity;
          
        if (Input.GetKey(KeyCode.UpArrow))
        {
            foward();

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

            backward();

          
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            left();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            right();
        }

       //In air, i should probably use layer or tag to assign the velocity declining to 0.

       
        if (Input.GetKey(KeyCode.R)){
            transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

          
        Vector3 movedPosition = transform.position;

        
        movedPosition = Vector3.ClampMagnitude(movedPosition, radius);
        transform.position =movedPosition;



    }


    private void OnTriggerEnter(Collider other)
    {
       


                if (other.gameObject.CompareTag("Untagged"))
                {
                    rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                    acel = 0.0f;
                    reverse_speed = 0.0f;
                   // rb.velocity = (transform.TransformDirection(0, 1, 0) * (gravity));//in air the graivity works as (-speed/80)

                }
            }
        }
       
    


