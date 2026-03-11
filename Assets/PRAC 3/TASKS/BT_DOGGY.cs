using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_DOGGY", menuName = "Behaviour Trees/BT_DOGGY", order = 1)]
public class BT_DOGGY : BehaviourTree
{    
    public override void OnConstruction()
    {
        root = new RepeatForeverDecorator();
        DynamicSelector dynamicSelector = new DynamicSelector();

        dynamicSelector.AddChild(
            new CONDITION_InstanceNear("1000", "BULLY"),
            new ACTION_Hide()
        );

        dynamicSelector.AddChild(
            new CONDITION_IsHungry(),
            ScriptableObject.CreateInstance<BT_EAT>()
        );

        dynamicSelector.AddChild(
            new CONDITION_InstanceNear("1000", "STICK", "true", "theStick"),
            ScriptableObject.CreateInstance<BT_CHASE_STICK>()
        );

        dynamicSelector.AddChild(
            new CONDITION_AlwaysTrue(),
            ScriptableObject.CreateInstance<BT_RELAXED_WALK>()
        );

        root.AddChild(dynamicSelector);
    }
}
