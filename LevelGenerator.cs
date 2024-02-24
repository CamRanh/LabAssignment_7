using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject obstaclePrefab;
    public int levelWidth = 24;
    public int levelHeight = 8;
    public float obstacleSpawnProbability = 0.2f;

    void Start()
    {
        GenerateGround();
        GenerateObstacles();
    }

    void GenerateGround()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                Instantiate(groundPrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }

    void GenerateObstacles()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                if (Random.Range(0f, 6f) < obstacleSpawnProbability)
                {
                    Instantiate(obstaclePrefab, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }
}
