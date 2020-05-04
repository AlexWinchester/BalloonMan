using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    public bool isMoving;
    public bool isBuilt;

    public Vector2 trajectory;
    public Vector2 moveVelocity;
    public Vector2 position;
    protected Vector2 previousPosition;

    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    
    //Awake is called as soon as component is added to GameObject
    protected virtual void Awake()
    {
        // Build Components
        Build();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        position = transform.position;
    }

    protected virtual void FixedUpdate()
    {

    }

    // Called after all Update methods have completed
    protected virtual void LateUpdate()
    {
        // Update Previous Position
        previousPosition = position;

        // Check if character is moving
        if (position == previousPosition)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    protected virtual void Build()
    {
        spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        if (sprite)
        {
            spriteRenderer.sprite = sprite;
        }
        isBuilt = true;
    }
}
