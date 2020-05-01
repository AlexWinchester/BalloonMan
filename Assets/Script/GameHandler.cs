using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float elapsedTime = 0;
    private float enemySpawnRate = 1F;
    public int slotCount = 0;
    public bool isDragging = false;

    private float camHalfWidth;
    public float camWidth;

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
        // Get camera dimensions
        float screenAspect = (float)Screen.width / (float)Screen.height;
        camHalfWidth = screenAspect * Camera.main.orthographicSize; // Camera.main.orthographicSize is camHalfHeight
        camWidth = 2.0f * camHalfWidth; // Get width of the camera

    }

    // Update is called once per frame
    void Update()
    {
        // Increment elapsed time
        elapsedTime += Time.deltaTime;
    }

}
