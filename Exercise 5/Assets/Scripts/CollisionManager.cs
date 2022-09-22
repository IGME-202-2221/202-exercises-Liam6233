using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    GameObject ship;

    SpriteRenderer shipColor;

    [SerializeField]
    List<GameObject> obsticalList;

    [SerializeField]
    GameObject colType; 

    // false = AABB true = Circle
    bool collisionMethod = false;
    // Start is called before the first frame update
    void Start()
    {
        shipColor = ship.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = ship;
        GameObject rock;
        bool collision;
        for(int i = 0; i < obsticalList.Count; i++)
        {
            rock = obsticalList[i];
            if (collisionMethod)
            {
                colType.GetComponent<TextMesh>().text = "Collision Mode: Circle Collision";
                collision = CircleCollision(player, rock);
            }
            else
            {
                colType.GetComponent<TextMesh>().text = "Collision Mode: AABB Collision";
                collision = AABBCollision(player, rock);
            }

            if (collision)
            {
                shipColor.color = Color.red;
                obsticalList[i].GetComponent<SpriteRenderer>().color = Color.red;
                i = obsticalList.Count;
                
            }
            else 
            {
                shipColor.color = Color.white;
                obsticalList[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    public void ChangeCollision()
    {
        collisionMethod = !collisionMethod;
    }
    public bool AABBCollision(GameObject player, GameObject obstical)
    {
        bool areColliding = false;
        Bounds playerBox = player.GetComponent<SpriteRenderer>().bounds;
        Bounds obsticalBox = obstical.GetComponent<SpriteRenderer>().bounds;

        if (obsticalBox.min.x < playerBox.max.x &&
            obsticalBox.max.x > playerBox.min.x &&
            obsticalBox.max.y > playerBox.min.y &&
            obsticalBox.min.y < playerBox.max.y)
        {
            areColliding = true;
        }
        return areColliding;
    }

    public bool CircleCollision(GameObject player, GameObject obstical)
    {
        bool isColliding = false;
        float playerRad = player.GetComponent<SpriteRenderer>().bounds.extents.x;
        float obRad = obstical.GetComponent<SpriteRenderer>().bounds.extents.y;

        float distance = Mathf.Pow(player.transform.position.x - obstical.transform.position.x, 2) 
            + Mathf.Pow(player.transform.position.y - obstical.transform.position.y, 2);
        if ((playerRad + obRad) > Mathf.Sqrt(distance))
        {
            isColliding = true;

        }
        return isColliding;
    }
}
