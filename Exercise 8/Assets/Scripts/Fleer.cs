using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    [SerializeField]
    GameObject fleeingFrom;
    // Start is called before the first frame update
   
    protected override void CalcSteeringForces()
    {
       totalSteeringForce += Flee(fleeingFrom.transform.position);
    }
}
