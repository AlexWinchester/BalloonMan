using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : Character
{
    public float testTime;
    public float testDistance;
    public float testSpeed;
    private Transform target;
    private Vector3 m_previousPosition;
    private Vector3 targetPreviousPosition;
    private Vector3 m_intersection;
    private Line m_trajectory;
    private Line targetTrajectory;
    private float targetSpeed;

    void Start()
    {
        m_previousPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPreviousPosition = target.position;
        speed = 2;

    }

    void Update()
    {
        testTime = Time.deltaTime;
        testDistance = GetDistance(target.position, targetPreviousPosition);
        testSpeed = GetSpeed(target);
        /*
        if (m_previousPosition != transform.position) m_trajectory = GetTrajectory(transform, m_previousPosition);
        if (targetPreviousPosition != target.position)
        {
            targetTrajectory = GetTrajectory(target, targetPreviousPosition);
            m_intersection = CalculateIntersection(m_trajectory, targetTrajectory);
        }
        else
        {
            m_intersection = target.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, m_intersection, speed * Time.deltaTime); //GetTargetDestination(target, targetPreviousPosition)
        */
        m_previousPosition = transform.position;
        targetPreviousPosition = target.position;
        
    }

    private Vector3 GetTargetDestination(Transform target, Vector3 previousPosition)
    {
        Vector3 targetDestination;
        Vector3 targetPosition = target.position;
        if (targetPosition == previousPosition)
        {
            // Target hasn't moved
            targetDestination = targetPosition;
            return targetDestination;
        }
        else
        {
            targetDestination = (targetPosition - previousPosition) * Time.deltaTime + targetPosition;
            return targetDestination;
        }

        //TODO: Predict a time other than Time.deltaTime for a player/enemy collision. Enemy should calculate a line for player's movement, 
        // then calculate the line the enemy should follow in order to collide with player.
    }

    private Line GetTrajectory(Transform target, Vector3 previousPosition)
    {
        float slope = (target.position.y -previousPosition.y) / (target.position.x - previousPosition.x); // M = ( Y2 - Y1 ) / ( X2 - X1 );
        float yIntercept = target.position.y + slope * target.position.x; // B = Y + M * X

        return new Line(slope, yIntercept);
    }

    private float GetDistance(Vector3 startPoint, Vector3 endPoint)
    {
        return Mathf.Sqrt( Mathf.Pow(endPoint.x - startPoint.x, 2) + Mathf.Pow(endPoint.y - startPoint.y, 2) ); // SQRT((x2 - x1)^2 + (y2 - y1)^2)
    }

    private float GetSpeed(Transform target)
    {
        return target.GetComponent<Character>().speed;
    }

    private Vector3 CalculateTrajectory(Transform subject, Transform target) 
    {
        Vector3 collisionPoint;
        float targetSlope, targetAxisIntersect;
        bool isCollision = false, isInfiniteYSlope = false, isMoving = true;
        Vector3 trajectory = new Vector3(0,0);
        Vector3 targetTrajectory = target.GetComponent<Character>().trajectory;

        // Calculate slope
        if (targetTrajectory.x == 0 && targetTrajectory.y != 0)
        {
            // Infinite slope in standard y = mx + b, use x = ny + c
            isInfiniteYSlope = true;
            targetSlope = targetTrajectory.x / targetTrajectory.y;
        }
        else if (targetTrajectory.x == 0 && targetTrajectory.y == 0)
        {
            // stationary target
            targetSlope = 0;
            isMoving = false;
        }
        else
        {
            targetSlope = targetTrajectory.y / targetTrajectory.x;
        }

        // calculate axis intercept

        if (!isInfiniteYSlope && isMoving)
        {
            // y = mx + b
            targetAxisIntersect = target.position.y + targetSlope * target.position.x;
        }
        else (isMoving) {
            targetAxisIntersect = target.position.x + targetSlope * target.position.y;
        }

            return trajectory;
        /*
         * https://www.polymathlove.com/special-polynomials/triangle-similarity/multivariable-equation-solver.html
         * Collision point is correct when time-to-point is equal for both subject and target
         * time-to-point = SQRT((x2 - x1)^2 + (y2 - y1)^2) / Speed
         * sqrt((x-p)^2+(y-q)^2)/v=sqrt((x-r)^2+(y-t)^2)/w
         * y = mx+b
         * sqrt((x-p)^2+(mx+b-q)^2)/v=sqrt((x-r)^2+(mx+b-t)^2)/w
         * x = sqrt(((-q^2)+(2*m*p+2b)*q-m^2*p^2-2*b*m*p-b^2)*w^4+((m^2+1)*t^2+((-2*m^2*q)-2*m*p-2*b)*t+(m^2+1)*r^2+((-2*m*q)-2*p
         * 
         * x = ny+c
         * sqrt((ny+c-p)^2+(y-q)^2)/v=sqrt((ny+c-r)^2+(y-t)^2)/w
         */
    }

    private Vector3 CalculatePointFromDistance(Vector3 originalPoint, Line line, float distance)
    {
        Vector3 newPoint = new Vector3();
        // Circle Equation ob

        return newPoint;
    }

    private Vector3 CalculateIntersection(Line line1, Line line2)
    {
        // MaX + Ba = MbX + Bb
        float xSlope, xIntercept, xIntersection, yIntersection;
        xSlope = line1.M - line2.M;
        xIntercept = line2.B - line1.B;
        xIntersection = xIntercept / xSlope;
        yIntersection = line1.M * xIntersection + line1.B;
        return new Vector3(xIntersection, yIntersection);
    }
}