using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{

    [SerializeField]
    GameObject seekTarget;

    public bool caughtTarget;
    protected override void CalcSteeringForces()
    {
        totalSteeringForce += Seek(seekTarget.transform.position);
        caughtTarget = CircleCollision(seekTarget);
        if (caughtTarget)
        {

            seekTarget.GetComponent<Fleer>().ChangePosition();
            caughtTarget = false;
            
        }
    }

    public bool CircleCollision(GameObject target)
    {
        bool isColliding = false;
        float seekerRad = GetComponent<SpriteRenderer>().bounds.extents.x;
        float targetRad = target.GetComponent<SpriteRenderer>().bounds.extents.y;

        float distance = Mathf.Pow(transform.position.x - target.transform.position.x, 2)
            + Mathf.Pow(transform.position.y - target.transform.position.y, 2);
        if ((seekerRad + targetRad) > Mathf.Sqrt(distance))
        {
            isColliding = true;
        }
        return isColliding;
    }
}
