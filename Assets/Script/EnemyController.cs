using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Character
{
    public float testTime;
    public float testDistance;
    public float testSpeed;
    public Vector2 collisionPoint;
    private Transform target;
    private Vector2 m_previousPosition;
    private Vector2 targetPreviousPosition;
    private Vector2 m_intersection;
    private Line m_trajectory;
    private Line targetTrajectory;

    public float subjectSpeed, targetSlope, targetAxisIntersect, targetSpeed = 0, numToBeSqrt, addend, denominator, x1, x2, y1, y2;

    void Start()
    {
        // Build Components
        Build();

        m_previousPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPreviousPosition = target.position;
        speed = 2;

    }

    void Update()
    {

        collisionPoint = Geometry2D.CalculateCollisionPoint(transform, target);


        transform.position = Vector2.MoveTowards(transform.position, Geometry2D.CalculateCollisionPoint(transform, target), speed * Time.deltaTime); 

        m_previousPosition = transform.position;
        targetPreviousPosition = target.position;

    }
}