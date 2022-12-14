using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{


    // fields
    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    Vector3 position = Vector3.negativeInfinity;
    

    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
       
    }

    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public Vector3 Direction
    {
        get { return direction; }
    }


    [SerializeField] 
    public float mass;

    [SerializeField]
    bool frictionApplied;

    [SerializeField]
    float frictionCoef;

    [SerializeField]
    bool gravityApplied;

    float gravityStrength = -3;

    //needed for bounce method
    [SerializeField]
    //public Camera cam;
    //static float height;
    //float width;
    // Start is called before the first frame update
    void Start()
    {
        

        position = transform.position;
        direction = Random.insideUnitCircle.normalized;
    }

    private void Awake()
    {
        //height = 2f * cam.orthographicSize;
        //width = height * cam.aspect;

        direction = Vector3.zero;
        velocity = Vector3.zero;
        acceleration = Vector3.zero;
        position = transform.position;
        direction = Random.insideUnitCircle.normalized;
        mass = 1;
    }

    // Update is called once per frame
    void Update()
    {   
        if (frictionApplied)
        {
            ApplyFriction(frictionCoef);
        }
        if (gravityApplied)
        {
            ApplyGravity(new Vector3(0, gravityStrength, 0));
        }

        velocity += acceleration * Time.deltaTime;

        position += velocity * Time.deltaTime;

        if (velocity != Vector3.zero)
        {
            direction = velocity.normalized;
        }
        transform.position = position;

        acceleration = Vector3.zero;
        //Bounce();

    }

    private void ApplyFriction(float coeff)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction *= coeff;
        ApplyForce(friction);

    }

    private void ApplyGravity(Vector3 force)
    {
        force.x = 0;
        force.z = 0;
        ApplyForce(force * mass);
    }

    /*
    private void Bounce()
    {
        if(transform.position.x <= cam.transform.position.x - width / 2 
            || transform.position.x >= cam.transform.position.x + width / 2)
        {
            velocity.x *= -1;
            GetComponent<SpriteRenderer>().color = Color.red; /// for debugging
        }
        if (transform.position.y <= cam.transform.position.y - height / 2
            || transform.position.y >= cam.transform.position.y + height / 2)
        {
            velocity.y *= -1;
            GetComponent<SpriteRenderer>().color = Color.red; // for debugging
        }
        
    }
    */
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }
}
