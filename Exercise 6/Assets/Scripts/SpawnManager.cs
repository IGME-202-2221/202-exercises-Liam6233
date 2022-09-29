using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private List<SpriteRenderer> animals = new List<SpriteRenderer>();

    public int minAnimals = 10;
    public int maxAnimals = 101;

    public SpriteRenderer elPrefab;
    public SpriteRenderer turtPrefab;
    public SpriteRenderer snailPrefab;
    public SpriteRenderer octoPrefab;
    public SpriteRenderer kangoPrefab;

    //private Vector3 minPosition;
    //private Vector3 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        //minPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
        //maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        CleanUp();
        int numAnimals = Random.Range(minAnimals, maxAnimals);
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
        // starts as elephant
        SpriteRenderer randomAnimal = elPrefab;
        
        // gets random number between 0 (in) and 1 (ex)
        float randNum = Random.Range(0f, 1f);

        // based on that number, uses non-uniform random to choose which
        // animal prefab to use. if num is greater than .75, then it stays elephant (25% chance)
        
        // 10% chance for octopus
        if (randNum < 0.1f)
        {
            randomAnimal = octoPrefab;
        }
        // 15% chance for snail
        else if (randNum < 0.25f)
        {
            randomAnimal = snailPrefab;
        }
        // 20% chance for turtle
        else if (randNum < 0.45f)
        {
            randomAnimal = turtPrefab;
        }
        // 30% chance for kangaroo
        else if(randNum < 0.75f)
        {
            randomAnimal = kangoPrefab;
        }


        return randomAnimal;
    }

    private SpriteRenderer SpawnAnimal()
    {

        // using guassian float for position which makes animals position be more centered around
        // the middle of the scene
        float gaussX = Gaussian(0f, 2f);
        float gaussY = Gaussian(0f, 1.35f);
        Vector3 animalPosition = new Vector3(gaussX, gaussY, 0f);
        //Vector3 animalPosition = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y,maxPosition.y), 0f);

        SpriteRenderer spawnedAnimal = Instantiate(ChooseRandomAnimal(), animalPosition, Quaternion.identity, transform);

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
