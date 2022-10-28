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

    public void ChangePosition()
    {
        float randomX = Random.Range(-9, 9);
        float randomY = Random.Range(-4, 4);

        transform.position = new Vector3(randomX, randomY, 0);
        physicsObject.Velocity = Vector3.zero;
    }
}
