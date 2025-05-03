using System;
using Unity.VisualScripting;
using UnityEngine;

[UnitTitle("On Global Event")]
public class GlobalEventNode : EventUnit<PlotEvent>
{
    [DoNotSerialize]
    public ValueInput plotEvent;

    [DoNotSerialize]
    public ValueOutput outputTrigger;

    private Action<PlotEvent> handler;

    protected override bool register => true;

    protected override void Definition()
    {
        base.Definition();
        plotEvent = ValueInput<PlotEvent>("PlotEvent", PlotEvent.OnBedInteract);
        outputTrigger = ValueOutput<int>("outputTrigger");
    }

    public override EventHook GetHook(GraphReference reference)
    {
        return new EventHook("GlobalEvent");
    }

    public override void StartListening(GraphStack stack)
    {
        base.StartListening(stack);
        var reference = stack.ToReference();

        handler = (evt) =>
        {
            Trigger(reference, evt);
        };
        EventBus.OnStateChanged += handler;
    }

    public override void StopListening(GraphStack stack)
    {
        base.StopListening(stack);

        if (handler != null)
            EventBus.OnStateChanged -= handler;
    }

    protected override void AssignArguments(Flow flow, PlotEvent evt)
    {
        var selected = flow.GetValue<PlotEvent>(plotEvent);
        int result = (evt == selected ? 1 : 0);
        flow.SetValue(outputTrigger, result);
    }
}
