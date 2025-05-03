using System;
using Unity.VisualScripting;
using UnityEngine;

[UnitTitle("Doorbell")]
public class DoorbellNode : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;

    [DoNotSerialize]
    public ControlOutput outputTrigger;

    [DoNotSerialize]
    private DoorbellService doorbell;

    protected override void Definition()
    {
        inputTrigger = ControlInput(
            "inputTrigger",
            (flow) =>
            {
                doorbell = Registry.Instance.Get<DoorbellService>();
                doorbell.Ring();
                return outputTrigger;
            }
        );
        outputTrigger = ControlOutput("outputTrigger");
    }
}
