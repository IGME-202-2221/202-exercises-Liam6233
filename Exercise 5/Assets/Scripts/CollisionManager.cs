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

    CollisionDetection dection;
    // false = AABB true = Circle
    bool collisionMethod = true;
    // Start is called before the first frame update
    void Start()
    {
        shipColor = ship.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionMethod)
        {
           for(int i = 0; i < obsticalList.Count; i++)
            {
                if(dection.CircleCollision(ship, obsticalList[i])){
                   shipColor.color = Color.red;
                   obsticalList[i].GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    shipColor.color = Color.white;
                    obsticalList[i].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
        else
        {
            for (int i = 0; i < obsticalList.Count; i++)
            {
                if (dection.CircleCollision(ship, obsticalList[i]))
                {
                    shipColor.color = Color.red;
                    obsticalList[i].GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    shipColor.color = Color.white;
                    obsticalList[i].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
    }

    public void ChangeCollision()
    {
        collisionMethod = !collisionMethod;
    }
}
