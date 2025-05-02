using System;
using Unity.VisualScripting;
using UnityEngine;

[UnitTitle("Check item in hands")]
public class CheckHandsNode : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;
    [DoNotSerialize]

    public ControlOutput outputTriggerTrue;
    [DoNotSerialize]

    public ControlOutput outputTriggerFalse;
    [DoNotSerialize]

    public ValueInput item;

    protected override void Definition()
    {
        inputTrigger = ControlInput("inputTrigger", (flow) => { 
            // player.HasItem(item);
            return outputTriggerTrue; 
        });
        outputTriggerTrue = ControlOutput("True");
        outputTriggerFalse = ControlOutput("False");
        item = ValueInput<PlotItem>("PlotItem", PlotItem.EntranceDoor);
    }
}
