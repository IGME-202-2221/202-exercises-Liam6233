using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{

    [SerializeField]
    float futureTime = 2f;

    [SerializeField]
    float wanderRadius = 2f;
    // Start is called before the first frame update
    protected override void CalcSteeringForces()
    {
        //totalSteeringForce += Wander1();
        totalSteeringForce += Wander2(futureTime, wanderRadius);
    }
}
