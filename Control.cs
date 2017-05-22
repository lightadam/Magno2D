using UnityEngine;

public class Control : MonoBehaviour {
    public Rigidbody2D rb;

    public float sidewaysForce;
    public Vector2 jumpVector;
    public bool isGrounded;

    public Transform grounder;
    public float radius;
    public LayerMask ground;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(sidewaysForce, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
       else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-sidewaysForce, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
        
        isGrounded = Physics2D.OverlapCircle(grounder.transform.position, radius, ground);

        if (Input.GetKey("w") && isGrounded == true)
        {
            rb.AddForce(jumpVector, ForceMode2D.Force);
        }
	}
}
