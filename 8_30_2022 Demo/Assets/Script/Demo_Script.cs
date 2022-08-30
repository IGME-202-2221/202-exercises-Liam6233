using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Script : MonoBehaviour
{
    [SerializeField]
    public float rotatorX, rotatorY,rotatorZ;
    
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
        //cam = new Camera();
    }
    
    // gets called first frame that the script is enabled
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cam.transform.Rotate(new Vector3(rotatorX, rotatorY, rotatorZ));
    }
}
