using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_EAT", menuName = "Behaviour Trees/BT_EAT", order = 1)]
public class BT_EAT : BehaviourTree
{
    public override void OnConstruction()
    {
        RepeatTimesDecorator threeTimesRepeat = new RepeatTimesDecorator("3");
        threeTimesRepeat.AddChild(
            new Sequence(
                new ACTION_Bark("BOW-WOW"),
                new ACTION_WaitForSeconds("2"),
                new ACTION_Bark("WOOF"),
                new ACTION_WaitForSeconds("1")
            )    
        );

        root = new RepeatUntilSuccessDecorator(
            new Sequence(
                new ACTION_Arrive("centreOfScene"),
                threeTimesRepeat,
                new ACTION_Quiet(),
                new Selector(
                    new Sequence(
                        new ACTION_Arrive("foodLocationOne"),
                        new CONDITION_InstanceNear("50", "FOOD"),
                        new ACTION_Eat()
                    ),
                    new Sequence(
                        new ACTION_Arrive("foodLocationTwo"),
                        new CONDITION_InstanceNear("50", "FOOD"),
                        new ACTION_Eat()
                    )
                )
            )
        );
    }
}
