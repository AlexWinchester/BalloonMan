using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometry2D : MonoBehaviour
{


    public static float GetDistance(Vector2 startPoint, Vector2 endPoint)
    {
        return Mathf.Sqrt(Mathf.Pow(endPoint.x - startPoint.x, 2) + Mathf.Pow(endPoint.y - startPoint.y, 2)); // SQRT((x2 - x1)^2 + (y2 - y1)^2)
    }

    public static Vector2 CalculateCollisionPoint(Transform subject, Transform target)
    {
        
        Vector2 collisionPoint;
        Character subjectCharacter = subject.GetComponent<Character>();
        Character targetCharacter = target.GetComponent<Character>();
        float subjectSpeed, targetSlope, targetAxisIntersect, targetSpeed = 0, numToBeSqrt, addend, denominator, x1, x2, y1, y2;
        bool isInfiniteYSlope = false, isMoving = true;
        Vector2 trajectory = new Vector2(0, 0);
        Vector2 targetTrajectory = targetCharacter.trajectory;
        targetSpeed = targetCharacter.speed;
        subjectSpeed = subjectCharacter.speed;

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

        if (!isMoving)
        {
            // Target is stationary, move towards target
            collisionPoint.x = target.position.x;
            collisionPoint.y = target.position.y;

            // Return Collision Point
            return collisionPoint;

        }
        else if (!isInfiniteYSlope)
        {
            // y = mx + b
            targetAxisIntersect = target.position.y - targetSlope * target.position.x;
            numToBeSqrt = Mathf.Pow(-2 * targetAxisIntersect * targetSlope * subjectSpeed * subjectSpeed + 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed - 2 * targetSlope * subject.position.y * targetSpeed * targetSpeed + 2 * targetSlope * target.position.y * subjectSpeed * subjectSpeed - 2 * subject.position.x * targetSpeed * targetSpeed + 2 * target.position.x * subjectSpeed * subjectSpeed, 2)
                - 4 * (-1 * targetSlope * targetSlope * subjectSpeed * subjectSpeed + targetSlope * targetSlope * targetSpeed * targetSpeed - subjectSpeed * subjectSpeed + targetSpeed * targetSpeed)
                * (-1 * targetAxisIntersect * targetAxisIntersect * subjectSpeed * subjectSpeed + targetAxisIntersect * targetAxisIntersect * targetSpeed * targetSpeed - 2 * targetAxisIntersect * subject.position.y * targetSpeed * targetSpeed + 2 * targetAxisIntersect * target.position.y * subjectSpeed * subjectSpeed + subject.position.x * subject.position.x * targetSpeed * targetSpeed + subject.position.y * subject.position.y * targetSpeed * targetSpeed - target.position.x * target.position.x * subjectSpeed * subjectSpeed - target.position.y * target.position.y * subjectSpeed * subjectSpeed);

            if (numToBeSqrt >= 0)
            {
                // Not negative
                addend = 2 * targetAxisIntersect * targetSlope * subjectSpeed * subjectSpeed - 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed + 2 * targetSlope * subject.position.y * targetSpeed * targetSpeed - 2 * targetSlope * target.position.y * subjectSpeed * subjectSpeed + 2 * subject.position.x * targetSpeed * targetSpeed - 2 * target.position.x * subjectSpeed * subjectSpeed;
                denominator = 2 * (-1 * targetSlope * targetSlope * subjectSpeed * subjectSpeed + targetSlope * targetSlope * targetSpeed * targetSpeed - subjectSpeed * subjectSpeed + targetSpeed * targetSpeed);
                x1 = (Mathf.Sqrt(numToBeSqrt) + addend) / denominator;
                x2 = (-1 * Mathf.Sqrt(numToBeSqrt) + addend) / denominator;
                y1 = targetSlope * x1 + targetAxisIntersect;
                y2 = targetSlope * x2 + targetAxisIntersect;

                // Check direction of movement
                // x Trajectory matches x1 difference, use 1st solution set
                if (targetTrajectory.x * (x1 - target.position.x) > 0)
                {
                    // Check 1st solution set is the closest point to the target
                    if (GetDistance(target.position, new Vector2(x1, y1)) <= GetDistance(target.position, new Vector2(x2, y2)))
                    {
                        collisionPoint.x = x1;
                        collisionPoint.y = y1;
                    }
                    else if (targetTrajectory.x * (x2 - target.position.x) > 0)
                    {
                        collisionPoint.x = x2;
                        collisionPoint.y = y2;
                    }
                    else
                    {
                        // Something went wrong, move to target
                        collisionPoint = target.position;
                    }
                }
                else if (targetTrajectory.x * (x2 - target.position.x) > 0)
                {
                    collisionPoint.x = x2;
                    collisionPoint.y = y2;
                }
                else
                {
                    // Something went wrong, move to target
                    collisionPoint = target.position;
                }

                // Return Collision Point
                return collisionPoint;
            }
            else
            {
                // Negative square root, would error. Move to target.
                collisionPoint = target.position;

            }
        }
        else
        {
            // x = ny + c
            targetAxisIntersect = target.position.x - targetSlope * target.position.y;
            numToBeSqrt = Mathf.Pow(-2 * targetAxisIntersect * targetSlope * subjectSpeed * subjectSpeed + 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed - 2 * targetSlope * subject.position.x * targetSpeed * targetSpeed + 2 * targetSlope * target.position.x * subjectSpeed * subjectSpeed - 2 * subject.position.y * targetSpeed * targetSpeed + 2 * target.position.y * subjectSpeed * subjectSpeed, 2)
                - 4 * (-1 * targetSlope * targetSlope * subjectSpeed * subjectSpeed + targetSlope * targetSlope * targetSpeed * targetSpeed - subjectSpeed * subjectSpeed + targetSpeed * targetSpeed)
                * (-1 * targetAxisIntersect * targetAxisIntersect * subjectSpeed * subjectSpeed + targetAxisIntersect * targetAxisIntersect * targetSpeed * targetSpeed - 2 * targetAxisIntersect * subject.position.x * targetSpeed * targetSpeed + 2 * targetAxisIntersect * target.position.x * subjectSpeed * subjectSpeed + subject.position.x * subject.position.x * targetSpeed * targetSpeed + subject.position.y * subject.position.y * targetSpeed * targetSpeed - target.position.x * target.position.x * subjectSpeed * subjectSpeed - target.position.y * target.position.y * subjectSpeed * subjectSpeed);

            if (numToBeSqrt >= 0)
            {
                // Not negative
                addend = 2 * targetAxisIntersect * targetSlope * subjectSpeed * subjectSpeed - 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed + 2 * targetSlope * subject.position.x * targetSpeed * targetSpeed - 2 * targetSlope * target.position.x * subjectSpeed * subjectSpeed + 2 * subject.position.y * targetSpeed * targetSpeed - 2 * target.position.y * subjectSpeed * subjectSpeed;
                denominator = 2 * (-1 * targetSlope * targetSlope * subjectSpeed * subjectSpeed + targetSlope * targetSlope * targetSpeed * targetSpeed - subjectSpeed * subjectSpeed + targetSpeed * targetSpeed);
                y1 = (Mathf.Sqrt(numToBeSqrt) + addend) / denominator;
                y2 = (-1 * Mathf.Sqrt(numToBeSqrt) + addend) / denominator;
                x1 = targetSlope * y1 + targetAxisIntersect;
                x2 = targetSlope * y2 + targetAxisIntersect;

                // Check direction of movement
                // y Trajectory matches y1 difference, use 1st solution set
                if (targetTrajectory.y * (y1 - target.position.y) > 0)
                {
                    // Check 1st solution set is the closest point to the target
                    if (GetDistance(target.position, new Vector2(x1, y1)) <= GetDistance(target.position, new Vector2(x2, y2)))
                    {
                        collisionPoint.x = x1;
                        collisionPoint.y = y1;
                    }
                    else if (targetTrajectory.y * (y2 - target.position.y) > 0)
                    {
                        collisionPoint.x = x2;
                        collisionPoint.y = y2;
                    }
                    else
                    {
                        // Something went wrong, move to target
                        collisionPoint = target.position;
                    }
                }
                else if (targetTrajectory.y * (y2 - target.position.y) > 0)
                {
                    collisionPoint.x = x2;
                    collisionPoint.y = y2;
                }
                else
                {
                    // Something went wrong, move to target
                    collisionPoint = target.position;
                }

                // Return Collision Point
                return collisionPoint;
            }
            else
            {
                // Negative square root, would error. Move to target.
                collisionPoint = target.position;

            }
        }

        // Something went wrong, move towards target
        collisionPoint.x = target.position.x;
        collisionPoint.y = target.position.y;

        // Return Collision Point
        return collisionPoint;

        /*
         * https://www.polymathlove.com/special-polynomials/triangle-similarity/multivariable-equation-solver.html
         * Collision point is correct when time-to-point is equal for both subject and target
         * time-to-point = SQRT((x2 - x1)^2 + (y2 - y1)^2) / Speed
         * sqrt((x-p)^2+(y-q)^2)/v=sqrt((x-r)^2+(y-t)^2)/w
         * y = mx+b
         * sqrt((x-p)^2+(mx+b-q)^2)/v=sqrt((x-r)^2+(mx+b-t)^2)/w
         * x = (sqrt((-2 b m v^2 + 2 b m w^2 - 2 m q w^2 + 2 m t v^2 - 2 p w^2 + 2 r v^2)^2 - 4 (-m^2 v^2 + m^2 w^2 - v^2 + w^2) (-b^2 v^2 + b^2 w^2 - 2 b q w^2 + 2 b t v^2 + p^2 w^2 + q^2 w^2 - r^2 v^2 - t^2 v^2)) + 2 b m v^2 - 2 b m w^2 + 2 m q w^2 - 2 m t v^2 + 2 p w^2 - 2 r v^2)/(2 (-m^2 v^2 + m^2 w^2 - v^2 + w^2))
         * x = (-sqrt((-2 b m v^2 + 2 b m w^2 - 2 m q w^2 + 2 m t v^2 - 2 p w^2 + 2 r v^2)^2 - 4 (-m^2 v^2 + m^2 w^2 - v^2 + w^2) (-b^2 v^2 + b^2 w^2 - 2 b q w^2 + 2 b t v^2 + p^2 w^2 + q^2 w^2 - r^2 v^2 - t^2 v^2)) + 2 b m v^2 - 2 b m w^2 + 2 m q w^2 - 2 m t v^2 + 2 p w^2 - 2 r v^2)/(2 (-m^2 v^2 + m^2 w^2 - v^2 + w^2))
         * 
         * x = (sqrt((-2 * targetAxisIntersect * targetSlope * subjectSpeed * subjectSpeed + 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed  - 2 * targetSlope * subject.position.y * targetSpeed * targetSpeed + 2 * targetSlope * target.position.y * subjectSpeed * subjectSpeed - 2 subject.position.x * targetSpeed * targetSpeed + 2 * target.position.x * subjectSpeed * subjectSpeed)^2 - 4 * (-1 * targetSlope * targetSlope * subjectSpeed * subjectSpeed + targetSlope * targetSlope * targetSpeed * targetSpeed - subjectSpeed * subjectSpeed + targetSpeed * targetSpeed) (-1 * targetAxisIntersect * targetAxisIntersect * subjectSpeed * subjectSpeed + targetAxisIntersect * targetAxisIntersect * targetSpeed * targetSpeed - 2 * targetAxisIntersect * subject.position.y * targetSpeed * targetSpeed + 2 * targetAxisIntersect * target.position.y * subjectSpeed * subjectSpeed + subject.position.x * subject.position.x * targetSpeed * targetSpeed + subject.position.y * subject.position.y * targetSpeed * targetSpeed - target.position.x * target.position.x * subjectSpeed * subjectSpeed - target.position.y * target.position.y * subjectSpeed * subjectSpeed)) + 2 * targetAxisIntersect * targetSlope * subjectSpeed * subjectSpeed - 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed + 2 * targetSlope * subject.position.y * targetSpeed * targetSpeed - 2 * targetSlope * target.position.y * subjectSpeed * subjectSpeed + 2 * subject.position.x * targetSpeed * targetSpeed - 2 * target.position.x * subjectSpeed * subjectSpeed)/(2 * (-1 * targetSlope * targetSlope  * subjectSpeed * subjectSpeed + targetSlope * targetSlope * targetSpeed * targetSpeed - subjectSpeed * subjectSpeed + targetSpeed * targetSpeed ))
         * x = (-1 * sqrt((-2 * targetAxisIntersect * targetSlope * subjectSpeed * subjectSpeed + 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed  - 2 * targetSlope * subject.position.y * targetSpeed * targetSpeed + 2 * targetSlope * target.position.y * subjectSpeed * subjectSpeed - 2 subject.position.x * targetSpeed * targetSpeed + 2 * target.position.x * subjectSpeed * subjectSpeed)^2 - 4 * (-1 * targetSlope * targetSlope * subjectSpeed * subjectSpeed + targetSlope * targetSlope * targetSpeed * targetSpeed - subjectSpeed * subjectSpeed + targetSpeed * targetSpeed) (-1 * targetAxisIntersect * targetAxisIntersect * subjectSpeed * subjectSpeed + targetAxisIntersect * targetAxisIntersect * targetSpeed * targetSpeed - 2 * targetAxisIntersect * subject.position.y * targetSpeed * targetSpeed + 2 * targetAxisIntersect * target.position.y * subjectSpeed * subjectSpeed + subject.position.x * subject.position.x * targetSpeed * targetSpeed + subject.position.y * subject.position.y * targetSpeed * targetSpeed - target.position.x * target.position.x * subjectSpeed * subjectSpeed - target.position.y * target.position.y * subjectSpeed * subjectSpeed)) + 2 * targetAxisIntersect * targetSlope * subjectSpeed * subjectSpeed - 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed + 2 * targetSlope * subject.position.y * targetSpeed * targetSpeed - 2 * targetSlope * target.position.y * subjectSpeed * subjectSpeed + 2 * subject.position.x * targetSpeed * targetSpeed - 2 * target.position.x * subjectSpeed * subjectSpeed)/(2 * (-1 * targetSlope * targetSlope  * subjectSpeed * subjectSpeed + targetSlope * targetSlope * targetSpeed * targetSpeed - subjectSpeed * subjectSpeed + targetSpeed * targetSpeed ))
         * 
         * x = ny+c
         * sqrt((ny+c-p)^2+(y-q)^2)/v=sqrt((ny+c-r)^2+(y-t)^2)/w 
         * y = (sqrt((-2 b m v^2 + 2 b m w^2 - 2 m p w^2 + 2 m r v^2 - 2 q w^2 + 2 t v^2)^2 - 4 (-m^2 v^2 + m^2 w^2 - v^2 + w^2) (-b^2 v^2 + b^2 w^2 - 2 b p w^2 + 2 b r v^2 + p^2 w^2 + q^2 w^2 - r^2 v^2 - t^2 v^2)) + 2 b m v^2 - 2 b m w^2 + 2 m p w^2 - 2 m r v^2 + 2 q w^2 - 2 t v^2)/(2 (-m^2 v^2 + m^2 w^2 - v^2 + w^2))
         * y = (-sqrt((-2 b m v^2 + 2 b m w^2 - 2 m p w^2 + 2 m r v^2 - 2 q w^2 + 2 t v^2)^2 - 4 (-m^2 v^2 + m^2 w^2 - v^2 + w^2) (-b^2 v^2 + b^2 w^2 - 2 b p w^2 + 2 b r v^2 + p^2 w^2 + q^2 w^2 - r^2 v^2 - t^2 v^2)) + 2 b m v^2 - 2 b m w^2 + 2 m p w^2 - 2 m r v^2 + 2 q w^2 - 2 t v^2)/(2 (-m^2 v^2 + m^2 w^2 - v^2 + w^2))
         * 
         * y = (sqrt((-2 * targetAxisIntersect * targetSlope *subjectSpeed*subjectSpeed+ 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed - 2 * targetSlope * subject.position.x * targetSpeed * targetSpeed + 2 targetSlope * target.position.x *subjectSpeed*subjectSpeed- 2 * subject.position.y * targetSpeed * targetSpeed + 2 * target.position.y *subjectSpeed* v)^2 - 4 * (-1 * targetSlope * targetSlope *subjectSpeed*subjectSpeed+ targetSlope * targetSlope * targetSpeed * targetSpeed -subjectSpeed*subjectSpeed+ targetSpeed * targetSpeed) (-1 * targetAxisIntersect * targetAxisIntersect *subjectSpeed*subjectSpeed+ targetAxisIntersect * targetAxisIntersect * targetSpeed * targetSpeed - 2 * targetAxisIntersect * subject.position.x * targetSpeed * targetSpeed + 2 * targetAxisIntersect * target.position.x *subjectSpeed*subjectSpeed+ subject.position.x * subject.position.x * targetSpeed * targetSpeed + subject.position.y * subject.position.y * targetSpeed * targetSpeed - target.position.x * target.position.x *subjectSpeed*subjectSpeed- target.position.y * target.position.y *subjectSpeed* subjectSpeed)) + 2 * targetAxisIntersect * targetSlope *subjectSpeed*subjectSpeed- 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed + 2 * targetSlope * subject.position.x * targetSpeed * targetSpeed - 2 * targetSlope * target.position.x *subjectSpeed*subjectSpeed+ 2 * subject.position.y * targetSpeed * targetSpeed - 2 * target.position.y *subjectSpeed*subjectSpeed)/(2 *(-1 * targetSlope * targetSlope *subjectSpeed*subjectSpeed+ targetSlope * targetSlope * targetSpeed * targetSpeed -subjectSpeed*subjectSpeed+ targetSpeed * targetSpeed))
         * y = (-sqrt((-2 * targetAxisIntersect * targetSlope *subjectSpeed*subjectSpeed+ 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed - 2 * targetSlope * subject.position.x * targetSpeed * targetSpeed + 2 targetSlope * target.position.x *subjectSpeed*subjectSpeed- 2 * subject.position.y * targetSpeed * targetSpeed + 2 * target.position.y *subjectSpeed* v)^2 - 4 * (-1 * targetSlope * targetSlope *subjectSpeed*subjectSpeed+ targetSlope * targetSlope * targetSpeed * targetSpeed -subjectSpeed*subjectSpeed+ targetSpeed * targetSpeed) (-1 * targetAxisIntersect * targetAxisIntersect *subjectSpeed*subjectSpeed+ targetAxisIntersect * targetAxisIntersect * targetSpeed * targetSpeed - 2 * targetAxisIntersect * subject.position.x * targetSpeed * targetSpeed + 2 * targetAxisIntersect * target.position.x *subjectSpeed*subjectSpeed+ subject.position.x * subject.position.x * targetSpeed * targetSpeed + subject.position.y * subject.position.y * targetSpeed * targetSpeed - target.position.x * target.position.x *subjectSpeed*subjectSpeed- target.position.y * target.position.y *subjectSpeed* subjectSpeed)) + 2 * targetAxisIntersect * targetSlope *subjectSpeed*subjectSpeed- 2 * targetAxisIntersect * targetSlope * targetSpeed * targetSpeed + 2 * targetSlope * subject.position.x * targetSpeed * targetSpeed - 2 * targetSlope * target.position.x *subjectSpeed*subjectSpeed+ 2 * subject.position.y * targetSpeed * targetSpeed - 2 * target.position.y *subjectSpeed*subjectSpeed)/(2 *(-1 * targetSlope * targetSlope *subjectSpeed*subjectSpeed+ targetSlope * targetSlope * targetSpeed * targetSpeed -subjectSpeed*subjectSpeed+ targetSpeed * targetSpeed))
         */
    }
    public static Vector2 CalculateIntersection(Line line1, Line line2)
    {
        // MaX + Ba = MbX + Bb
        float xSlope, xIntercept, xIntersection, yIntersection;
        xSlope = line1.M - line2.M;
        xIntercept = line2.B - line1.B;
        xIntersection = xIntercept / xSlope;
        yIntersection = line1.M * xIntersection + line1.B;
        return new Vector2(xIntersection, yIntersection);
    }
}
