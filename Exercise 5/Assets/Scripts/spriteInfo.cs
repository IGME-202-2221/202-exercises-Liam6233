using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteInfo : MonoBehaviour
{
    [SerializeField]
    GameObject prefabObject;

    Bounds spriteBox;
    BoundingSphere colCircle;
    // Start is called before the first frame update
    void Start()
    {
        spriteBox = prefabObject.GetComponent<SpriteRenderer>().bounds;
        colCircle = new BoundingSphere(prefabObject.transform.position, spriteBox.max.x / 2);

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(prefabObject.transform.position, spriteBox.extents.x);
    }
}
