using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PhysicsObject))]

public abstract class Agent : MonoBehaviour
{

    //Abstract class that can't put it on any game objects

    [SerializeField]
    protected PhysicsObject physicsObject;


    [SerializeField]
    float maxSpeed = 2f;

    [SerializeField]
    float maxForce = 2f;

    Vector3 pos;
    float rad;

    float timer;

    protected Vector3 totalSteeringForce;
    // Start is called before the first frame update
    void Start()
    {
        physicsObject = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        totalSteeringForce = Vector3.zero;
        CalcSteeringForces();
        FaceDirection();

        totalSteeringForce  = Vector3.ClampMagnitude(totalSteeringForce, maxForce);
  
        physicsObject.ApplyForce(totalSteeringForce);
        timer += Time.deltaTime;
    }

    protected abstract void CalcSteeringForces();

    // make sure targetPosition parameter is already in world space
    public Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = targetPosition - transform.position;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 seekForce = desiredVelocity - physicsObject.Velocity;

        return seekForce;
    }

    public Vector3 Flee(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = transform.position - targetPosition;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 fleeForce = desiredVelocity - physicsObject.Velocity;

        return fleeForce;
    }

    public void FaceDirection()
    {
        Vector3 direction = physicsObject.Velocity.normalized;

        physicsObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction); 
    }


    public Vector3 Wander(float futureTime, float wanderRad)
    {
        // pick future position from a circle in front of object
        Vector3 wanderPos = GetFuturePosition(futureTime);
        pos = wanderPos;
        rad = wanderRad;
        float wanderAngle = Random.Range(0f, 360f);
        wanderPos.x += Mathf.Cos(wanderAngle) * wanderRad;
        wanderPos.y += Mathf.Sin(wanderAngle) * wanderRad;

        return Seek(wanderPos);
       
    }

    public Vector3 Wander2()
    {
        float wanderAngle = Random.Range(-20f, 21f);
        if(timer > 1)
        {
            float offset = Random.Range(-5f, 6f);
            wanderAngle += offset;
            timer = 0;
        }
        Vector3 wanderPos = physicsObject.Direction;

        return Seek(wanderPos);
        

    }
    public Vector3 GetFuturePosition(float time)
    {
        // simplest way to calculate it is by multiplying current velocity by time
        Vector3 futurePos =physicsObject.Velocity * time;

        return futurePos;
    }

    public Vector3 StayInBounds(Vector2 worldSize, float futureTime)
    {

        // find future position,
        // check if going outside of camera bounds
        // apply steering force to push it in different direction
        Vector3 position = GetFuturePosition(futureTime);

        if(position.x >= worldSize.x|| position.x <= -worldSize.x || position.y >= worldSize.y || position.y <= -worldSize.y)
        {
            return Seek(Vector3.zero);
        }
        else
        {
            // if not worried about out of bounds, return no force
            return Vector3.zero;
        }
        
       

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pos, rad);
        Gizmos.DrawLine(pos, totalSteeringForce);

    }


}
