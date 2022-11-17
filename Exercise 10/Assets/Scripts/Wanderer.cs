using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{

    [SerializeField]
    float futureTime = 2f;


    [SerializeField]
    Vector2 worldSize;

    Vector3 boundsForce;

    private void Awake()
    {
        worldSize.y = Camera.main.orthographicSize;
        worldSize.x = Camera.main.aspect * worldSize.y;

        //worldSize *= 0.8f;
    }
    // Start is called before the first frame update
    protected override void CalcSteeringForces()
    {
        totalSteeringForce +=  Wander();
        boundsForce = StayInBounds(worldSize, futureTime);
        totalSteeringForce += boundsForce;
        totalSteeringForce += Seperation();
    }






}
