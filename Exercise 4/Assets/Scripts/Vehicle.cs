using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;


    Vector3 vehiclePosition = new Vector3(0, 0, 0);


    Vector3 direction = new Vector3(0, 0, 0);
    Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        vehiclePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Quaternion.Euler(0, 0, 1 * Time.deltaTime) * direction;

        velocity = direction * speed * Time.deltaTime;

        vehiclePosition += velocity;
        transform.position = vehiclePosition;

        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }


}
