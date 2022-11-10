using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TagStates
{
    NotIt,
    It,
    Counting
}
public class TagPlayer : Agent
{

    public TagStates currentState = TagStates.NotIt;
    [SerializeField]
    Vector2 worldSize;

    [SerializeField]
    float countTime;
    float timer;
    [SerializeField]
    AgentManager manager;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        worldSize.y = Camera.main.orthographicSize;
        worldSize.x = Camera.main.aspect * worldSize.y;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        //worldSize *= 0.8f;
    }
    protected override void CalcSteeringForces()
    {
        switch (currentState)
        {
            case TagStates.NotIt:
                totalSteeringForce += Flee(manager.Agents[manager.ItAgentIndex].transform.position);
                break;
            case TagStates.It:
                // seek nearest not it agent
                totalSteeringForce += Seek(manager.Agents[manager.FindNearestPlayer()].transform.position);
                break;
            case TagStates.Counting:
                //counts down then turns into it
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    ChangeState(TagStates.It);
                }
                break;
        }

        totalSteeringForce += StayInBounds(worldSize, 2);
    }

    public void ChangeState(TagStates newState)
    {
        switch (newState)
        {
            case TagStates.NotIt:
    
                break;
            case TagStates.It:
                
                break;
            case TagStates.Counting:
                timer = countTime;
                
                break;
        }
        spriteRenderer.sprite = manager.managerSprites[(int)newState];
        currentState = newState;
    }

    
}
