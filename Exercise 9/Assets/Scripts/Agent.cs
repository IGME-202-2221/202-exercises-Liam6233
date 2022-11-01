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


    public Vector3 Wander1()
    {

        // first way of implementing Wander behavior
        // seeking random position
        Vector3 randomPos = transform.position;

        randomPos.x += Random.Range(-10f, 10f);
        randomPos.y+= Random.Range(-10f, 10f);
       
        return Seek(randomPos);


    }

    public Vector3 Wander2(float futureTime, float wanderRad)
    {
        // pick future position from a circle in front of object
        Vector3 wanderPos = GetFuturePosition(futureTime);

        float wanderAngle = Random.Range(0f, 360f);
        wanderPos.x += Mathf.Cos(wanderAngle) * wanderRad;
        wanderPos.y += Mathf.Sin(wanderAngle) * wanderRad;

        return Seek(wanderPos);
       
    }
    public Vector3 GetFuturePosition(float time)
    {
        Vector3 futurePos = Vector3.zero;


        // simplest way to calculate it is by multiplying current velocity by time
        futurePos = physicsObject.Velocity * time;

        // or use acceleration

        //futurePos = physicsObject.acceleration * time;
        return futurePos;
    }

    public void StayInBounds()
    {
        // find future position,
        // check if going outside of camera bounds
        // apply steering force to push it in different direction
    }

}
