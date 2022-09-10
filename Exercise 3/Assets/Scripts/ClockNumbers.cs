using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField]
    GameObject clockNumberPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject clockNumber;

        for (int i = 1; i <= 12; i++)
        {
            clockNumber = Instantiate(clockNumberPrefab);


            //	Set Position
            float angle = (Mathf.PI / 6) * i+1.5f;
            clockNumber.transform.position = new Vector3(-Mathf.Cos(angle) * 2.25f, Mathf.Sin(angle) * 2.25f,0);
            //	Set Text
            clockNumber.GetComponent<TextMesh>().text = i.ToString();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
