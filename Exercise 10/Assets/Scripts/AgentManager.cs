using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField]
    Agent agentPrefab;

    [SerializeField]
    int agentSpawnCount;

    [SerializeField]
    public List<Sprite> managerSprites = new List<Sprite>();
   
    
    List<Agent> agents = new List<Agent>();

    int itAgentIndex;
    public int ItAgentIndex
    {
        get { return itAgentIndex; }
    }

    public List<Agent> Agents { get { return agents; } }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < agentSpawnCount; i++)
        {
            agents.Add(Instantiate(agentPrefab));
            agents[i].Init(this);

            ((TagPlayer)agents[i]).ChangeState(TagStates.NotIt);


        }
        if(agents.Count > 0)
        {
            TagPlayer(0);
            
        }
         
    }

    void Update()
    {
      
    }

    public void TagPlayer(int itPlayerIndex)
    {
        itAgentIndex = itPlayerIndex;

        ((TagPlayer)agents[itAgentIndex]).ChangeState(TagStates.It);
    }

    public int FindNearestPlayer()
    {
        int nearestPlayerIndex = 0;
        Vector3 nearestPlayer = Vector3.positiveInfinity;
        for(int i = 0; i < agents.Count-1; i++)
        {
            if(i != itAgentIndex)
            {
                //float distance = 
            }
        }

        return nearestPlayerIndex;
    }

}
