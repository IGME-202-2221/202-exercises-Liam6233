using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    List<PhysicsObject> monsters;

    
    [SerializeField]
    Vector3 mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        

        foreach(PhysicsObject obj in monsters)
        {
            // calculate force from mouse pos

            Vector3 mouseForce = new Vector3(mousePos.x - obj.transform.position.x, mousePos.y - obj.transform.position.y, 0);
            // add force to physics object
            obj.ApplyForce(mouseForce);
        }
    }
}
