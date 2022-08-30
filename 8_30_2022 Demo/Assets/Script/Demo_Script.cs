using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Script : MonoBehaviour
{
    [SerializeField]
    public float rotator;
    
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rotator = 0;
        cam = new Camera();
    }
    
    // gets called first frame that the script is enabled
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotator < 361)
        {
            rotator += 1f;
        }
        else
        {
            rotator = 0;
        }
        cam.transform.Rotate(new Vector3(0, rotator, 0));
        
    }
}
