using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Battlefield : MonoBehaviour
{
    public float radius;

    public int monsterCount;

    public List<GameObject> monsterCatalog;
    public List<float> distribution;

    private List<GameObject> monsters;

    // Start is called before the first frame update
    void Start()
    {
        monsters = new List<GameObject>();

        float cumsum = 0.0f;
        for(int i = 0; i < distribution.Count; i++)
        {
            cumsum += distribution[i];
            distribution[i] = cumsum;
        }

        for(int i = 0; i < monsterCount; i++)
        {
            float num = Utils.getRandomFloat(0.0f, 1.0f);
            int k = 0;
            while(distribution[k] < num) k++;
            Vector2 randPoint = UnityEngine.Random.insideUnitCircle;
            GameObject obj = Instantiate(monsterCatalog[k], transform.position + new Vector3(randPoint.x * radius, 0.0f, randPoint.y * radius), Quaternion.identity);
            monsters.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
