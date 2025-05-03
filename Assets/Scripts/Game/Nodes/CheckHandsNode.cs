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

    private PlayerInteract player;
    private ItemService itemService;

    protected override void Definition()
    {
        inputTrigger = ControlInput(
            "inputTrigger",
            (flow) =>
            {
                player = Registry.Instance.Get<PlayerInteract>();
                itemService = Registry.Instance.Get<ItemService>();
                if (player.GetHeldObject() == itemService[flow.GetValue<PlotItem>(item)])
                    return outputTriggerTrue;
                else
                    return outputTriggerFalse;
            }
        );
        outputTriggerTrue = ControlOutput("True");
        outputTriggerFalse = ControlOutput("False");
        item = ValueInput<PlotItem>("PlotItem", PlotItem.FirstPaint);
    }
}
