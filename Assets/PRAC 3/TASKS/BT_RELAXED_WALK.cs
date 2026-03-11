using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_RELAXED_WALK", menuName = "Behaviour Trees/BT_RELAXED_WALK", order = 1)]
public class BT_RELAXED_WALK : BehaviourTree
{   
    public override void OnConstruction()
    {
        root = new RepeatForeverDecorator();

        DynamicSelector dynamicSelector = new DynamicSelector();

        dynamicSelector.AddChild(
            new CONDITION_isTimeOut(),
            new Sequence(
                new ACTION_ChangePointOfIntereset(),
                new ACTION_ResetTimer()
            )
        );

        dynamicSelector.AddChild(
            new CONDITION_AlwaysTrue(),
            new ACTION_WanderAround("currentPointOfInterest", "0.22")
        );

        root.AddChild( dynamicSelector );
    }
}
