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

    protected void Build()
    {
        boxCollider = this.gameObject.AddComponent<BoxCollider2D>();
        rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
        rigidBody.freezeRotation = true;
        spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        if (sprite)
        {
            spriteRenderer.sprite = sprite;
        }
        isBuilt = true;
    }
}
