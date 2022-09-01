using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureAdder : MonoBehaviour
{
    public GameObject prefab;

    public List<Vector3> positions;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempoObj;
        foreach (Vector3 pos in positions)
        {

            tempoObj = Instantiate(prefab);

            tempoObj.transform.localPosition = pos;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
