using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float elapsedTime;
    public int currentFrame, enemySpawnRate;
    public bool isDragging = false;

    public Sprite enemySprite;

    private float camHalfWidth;
    public float camWidth;

    public float halfWidth;
    public float halfHeight;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        currentFrame = 0;
        elapsedTime = 0;
        enemySpawnRate = 200;
        enemySprite = Resources.Load<Sprite>("Sprites/pin_cushion");

        halfWidth = 10;
        halfHeight = 5;

        // Get camera dimensions
        float screenAspect = (float)Screen.width / (float)Screen.height;
        camHalfWidth = screenAspect * Camera.main.orthographicSize; // Camera.main.orthographicSize is camHalfHeight
        camWidth = 2.0f * camHalfWidth; // Get width of the camera



    }

    // Update is called once per frame
    void Update()
    {
        // Check if enemy should spawn this frame
        if (currentFrame % enemySpawnRate == 0) {

            // Spawn enemy
            spawnEnemy(
                new Vector2(Random.value * halfWidth * 2 - halfWidth, Random.value * halfHeight * 2 - halfHeight),
                enemySprite,
                "SpawnedEnemy");
        }

        // Increment current frame
        currentFrame += 1;
        // Increment elapsed time
        elapsedTime += Time.deltaTime;
    }

    private void spawnEnemy(Vector2 location, Sprite sprite, string name)
    {
        // Helper Variables
        Vector2 spawnPoint;

        // Create Game Object
        GameObject enemy = new GameObject(name);

        // Create Components
        EnemyController enemyController = enemy.AddComponent<EnemyController>().Sprite(sprite) as EnemyController;

        // Set position
        spawnPoint = location;
        enemy.transform.position = spawnPoint;

    }

}
