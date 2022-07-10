using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnvironment : MonoBehaviour
{

    public GameObject rewardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        generateCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateCoins()
    {

        float coinHeight = 0.5F;

        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                Vector3 position = new Vector3(5+x*10,coinHeight,5+z*10);
                Instantiate(rewardPrefab, position, new Quaternion());
                coinHeight += 0.1F;
            }
        }
    }
}
