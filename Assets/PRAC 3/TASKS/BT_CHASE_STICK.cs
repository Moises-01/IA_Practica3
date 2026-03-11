using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_CHASE_STICK", menuName = "Behaviour Trees/BT_CHASE_STICK", order = 1)]
public class BT_CHASE_STICK : BehaviourTree
{
    public override void OnConstruction()
    {
        root = new Sequence(
            new ACTION_IncreaseSpeed(),
            new ACTION_Arrive("theStick"),
            new ACTION_Take("theStick"),
            new ACTION_Arrive("stickAbandonArea"),
            new ACTION_Drop("theStick"),
            new ACTION_DecreaseSpeed(),
            new ACTION_SetTag("theStick", "Untagged")
        );
    }
}
