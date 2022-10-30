using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    [SerializeField]
    GameObject fleeingFrom;
    // Start is called before the first frame update


    protected override void Update()
    {
        base.Update();
        if (CircleCollision(fleeingFrom))
        {
            float randomX = Random.Range(-8, 8);
            float randomY = Random.Range(-4, 4);

            physicsObject.Position = new Vector3(randomX, randomY, 0);
            totalSteeringForce = Vector3.zero;
        }
    }
    protected override void CalcSteeringForces()
    {
        totalSteeringForce += Flee(fleeingFrom.transform.position);
    }


    public bool CircleCollision(GameObject target)
    {
        bool isColliding = false;
        float seekerRad = GetComponent<SpriteRenderer>().bounds.extents.x;
        float targetRad = target.GetComponent<SpriteRenderer>().bounds.extents.x;

        float distance = Mathf.Pow(transform.position.x - target.transform.position.x, 2)
            + Mathf.Pow(transform.position.y - target.transform.position.y, 2);
        if ((seekerRad + targetRad) > Mathf.Sqrt(distance))
        {
            isColliding = true;
        }
        return isColliding;
    }
}
