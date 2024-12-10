using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoucingLaser : MonoBehaviour
{
    public int maxBounce = 5;
    public int currentBounce = 0;
    private Stack<Vector2> directions = new Stack<Vector2>();
    private Stack<Vector2> hitPoints = new Stack<Vector2>();
    public bool IsRunning = false;
    public Dictionary<Vector2, Vector2> bounceData = new Dictionary<Vector2, Vector2>();
    
    private void OnDrawGizmos()
    {
        var origin = transform.position;
        var direction = transform.right;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(origin, origin + direction);
        directions.Push(direction);
        hitPoints.Push(origin);

        while (currentBounce < maxBounce)
        {
            var inCommingDirection = directions.Pop();
            var hitPoint = hitPoints.Pop();
            
            var hit = Physics2D.Raycast(hitPoint + inCommingDirection * 0.05f, inCommingDirection);

            if (hit)
            {
                currentBounce++;
                hitPoints.Push(hit.point);
            }
        
            var vectorReflection = VectorReflect(inCommingDirection, hit.normal);
            directions.Push(vectorReflection);
            
            bounceData.Add(hit.point, vectorReflection);
        }

        foreach (var key in bounceData.Keys)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(key, key + bounceData[key]);
        }
    }
    
    private static Vector2 VectorReflect(Vector2 direction, Vector2 normal)
    {
        // Sử dụng Vector Projection
        var vectorProjection = normal * (VectorDot(normal, direction));
        
        // Tính vector reflection
        return direction - 2 * vectorProjection;
    }

    private static float VectorDot(Vector2 a, Vector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }
}