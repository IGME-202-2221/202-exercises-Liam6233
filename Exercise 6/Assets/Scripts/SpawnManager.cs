using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private List<SpriteRenderer> animals = new List<SpriteRenderer>();

    public SpriteRenderer elPrefab;
    public SpriteRenderer turtPrefab;
    public SpriteRenderer snailPrefab;
    public SpriteRenderer octoPrefab;
    public SpriteRenderer kangoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {

    }
}
