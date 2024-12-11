using UnityEngine;

public class EnemyRadialDetection : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private NavMeshPlayer _player;

    [field: SerializeField] public bool IsInRange { get; set; }
    
    private void Update()
    {
        var vectorFromPlayer = transform.position - _player.transform.position;
        var distanceFromPlayer = Mathf.Sqrt(vectorFromPlayer.x * vectorFromPlayer.x + vectorFromPlayer.y * vectorFromPlayer.y);
        
        IsInRange = distanceFromPlayer  <= _radius;
    }

    private void OnDrawGizmos()
    {
        var center = transform.position;
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(center, _radius);
    }
}