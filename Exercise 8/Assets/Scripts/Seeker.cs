using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{

    [SerializeField]
    GameObject seekTarget;

    

    protected override void CalcSteeringForces()
    {
        totalSteeringForce += Seek(seekTarget.transform.position);
    }
}
