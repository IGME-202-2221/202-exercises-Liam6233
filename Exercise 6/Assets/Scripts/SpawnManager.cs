using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private List<SpriteRenderer> animals = new List<SpriteRenderer>();

    public int numAnimals = 10;

    public SpriteRenderer elPrefab;
    public SpriteRenderer turtPrefab;
    public SpriteRenderer snailPrefab;
    public SpriteRenderer octoPrefab;
    public SpriteRenderer kangoPrefab;

    private Vector3 minPosition;
    private Vector3 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        minPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        CleanUp();

        // set number of animals
        for(int i = 0; i < numAnimals; i++)
        {
            // place animal


            // add to list
            animals.Add(SpawnAnimal());

        }
    }

    private SpriteRenderer ChooseRandomAnimal()
    {

        SpriteRenderer randomAnimal = elPrefab;

        float randNum = Random.Range(0, 1.1f);
        if(randNum < 0.1f)
        {
            randomAnimal = octoPrefab;
        }
        if(randNum > 0.1f && randNum <= 0.25f)
        {
            randomAnimal = snailPrefab;
        }
        

        return randomAnimal;
    }

    private SpriteRenderer SpawnAnimal()
    {
        Vector3 animalPosition = new Vector3(Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y,maxPosition.y),
            0f);

        SpriteRenderer spawnedAnimal = Instantiate(ChooseRandomAnimal(), animalPosition, Quaternion.identity);

        spawnedAnimal.color = Random.ColorHSV(0f, 1f,1f,1f,1f,1f);

        return spawnedAnimal;
    }

    private void CleanUp()
    {
        foreach(SpriteRenderer animal in animals)
        {
            Destroy(animal.gameObject);
        }

        animals.Clear();
    }

    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }


}
