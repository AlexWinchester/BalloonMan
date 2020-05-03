using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float elapsedTime;
    public int currentFrame, enemySpawnRate;
    public bool isDragging = false;
    public Vector2 enemySpawnPoint;

    public string testString;

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
            enemySpawnPoint = GetRandomLocation();
            spawnEnemy(
                GetRandomLocation(),
                enemySprite,
                "SpawnedEnemy");
        }

        
    }

    private void LateUpdate()
    {
        // Increment current frame
        currentFrame++;

        // Increment elapsed time
        elapsedTime += Time.deltaTime;
    }

    private GameObject spawnEnemy(Vector2 location, Sprite sprite, string name)
    {
       
        // Create Game Object
        GameObject enemy = new GameObject(name);

        // Set position
        enemy.transform.position = location;

        // Create Components
        EnemyController enemyController = enemy.AddComponent<EnemyController>();
        
        enemyController.Sprite(sprite);



        // Set position
        //enemyController.rigidBody.MovePosition(location);

        return enemy;

    }

    private Vector2 GetRandomLocation()
    {
        return new Vector2(Random.value * halfWidth * 2 - halfWidth, Random.value * halfHeight * 2 - halfHeight);
    }

}
