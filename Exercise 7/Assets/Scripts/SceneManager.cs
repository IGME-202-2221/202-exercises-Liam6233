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
    Camera cam;

    Vector3 mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();

        mousePos = cam.ViewportToWorldPoint(mousePos);

        foreach(PhysicsObject obj in monsters)
        {
            // calculate force from mouse pos
            
            Vector3 mouseForce = mousePos / obj.mass;
            // add force to physics object
            obj.ApplyForce(mouseForce);
        }
    }
}
