using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{

    float turnAmount = 360f/60f;

    public bool useDeltaTime = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!useDeltaTime)
        {
            transform.Rotate(new Vector3(0, 0, turnAmount));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -turnAmount * Time.deltaTime));
        }
    }
}
