using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoucingLaser : MonoBehaviour
{
    public int maxBounce = 5;
    
    private void OnDrawGizmos()
    {
        var origin = transform.position;
        var direction = transform.right;
        var ray = new Ray2D(origin, direction);

        for (var i = 0; i < maxBounce; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction);
            var hit = Physics2D.Raycast(ray.origin + ray.direction * 0.05f, ray.direction);

            if (hit)
            {
                var vectorReflection = VectorReflect(ray.direction, hit.normal);
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(hit.point, 0.1f);
                Gizmos.DrawLine(hit.point, hit.point + vectorReflection);
                
                ray.origin = hit.point;
                ray.direction = vectorReflection;
            }
            else
            {
                break;
            }
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