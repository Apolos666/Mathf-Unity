using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Agent Detect Target", story: "[Agent] Detect [Target]", category: "Action", id: "45aa4f012613901d69b7c7a927db3605")]
public partial class AgentDetectTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    private EnemyRadialDetection _enemyRadialDetection;

    protected override Status OnStart()
    {
        _enemyRadialDetection = Agent.Value.GetComponent<EnemyRadialDetection>();
        return base.OnStart();
    }

    protected override Status OnUpdate()
    {
        if (!_enemyRadialDetection.IsInRange) return Status.Running;
        
        return Status.Success;
    }
}

