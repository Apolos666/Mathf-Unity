using System;
using UnityEngine;

public class RidialTrigger : MonoBehaviour
{
    public Transform player;
    public float radius = 2f;
    public bool isInRange;
    
    private void OnDrawGizmos()
    {
        // Player position
        var playerPos = player.position;
        var bombPos = transform.position;
        
        // Vẽ circle
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        // Vẽ line từ bombs tới player
        var playerDir = playerPos - bombPos;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(bombPos, playerDir);
        
        // Length vector từ bombs tới player
        var lengthBombToPlayer = Mathf.Sqrt(playerDir.x * playerDir.x + playerDir.y * playerDir.y);
        
        isInRange = lengthBombToPlayer <= radius;
    }
}