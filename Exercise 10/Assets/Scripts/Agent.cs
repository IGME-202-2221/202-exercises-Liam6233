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

    private float wanderAngle = 0f;

    private float maxWanderAngle = 45f;

    private float maxWanderChangePerSec = 10f;

    AgentManager manager;


    [SerializeField]
    float stayInBoundsWeight = 3f;

    protected Vector3 totalSteeringForce;
    // Start is called before the first frame update
    void Start()
    {
        physicsObject = GetComponent<PhysicsObject>();
    }

    public void Init(AgentManager manager)
    {
        this.manager = manager;
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
    public Vector3 Seek(Vector3 targetPosition, float seekWeight = 1f)
    {

        Vector3 desiredVelocity = targetPosition - transform.position;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 seekForce = desiredVelocity - physicsObject.Velocity;

        return seekForce * seekWeight;
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


    public Vector3 Wander(float wanderWeight = 1f)
    {
        float maxWanderChange = maxWanderChangePerSec * Time.deltaTime;
        wanderAngle += Random.Range(-maxWanderChange, maxWanderChange);

        wanderAngle = Mathf.Clamp(wanderAngle, -maxWanderAngle, maxWanderAngle);

        Vector3 wanderTarget = Quaternion.Euler(0, 0, wanderAngle) * physicsObject.Direction.normalized + physicsObject.Position;

        return Seek(wanderTarget);
             
    }

    public Vector3 GetFuturePosition(float time)
    {
        // simplest way to calculate it is by multiplying current velocity by time
        Vector3 futurePos = physicsObject.Position + physicsObject.Velocity * time;

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
            return Seek(Vector3.zero, stayInBoundsWeight);
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
   
    }
    
    public Vector3 Seperation()
    {
        Vector3 seperateForce = Vector3.zero;
        float sqrDistance;

        foreach(Agent other in manager.Agents)
        {
            sqrDistance = Vector3.SqrMagnitude(physicsObject.Position - other.physicsObject.Position);

            if(sqrDistance != 0)
            {
                seperateForce += Flee(other.physicsObject.Position) * (1f/ sqrDistance);
            }
            
        }

        return seperateForce;
    }



}
