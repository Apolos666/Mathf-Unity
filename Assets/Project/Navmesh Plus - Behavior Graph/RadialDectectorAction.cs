using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Radial Dectector", story: "Assign [IsInRange] If [Player] in [EnemyRadialDetector]", category: "Action", id: "da59915f05e5c11154736a909207a4f9")]
public partial class RadialDectectorAction : Action
{
    [SerializeReference] public BlackboardVariable<bool> IsInRange;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<EnemyRadialDetection> EnemyRadialDetector;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        IsInRange.Value = EnemyRadialDetector.Value.IsInRange;
        return Status.Success;
    }
}

