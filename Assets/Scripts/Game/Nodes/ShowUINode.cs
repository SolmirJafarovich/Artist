using System;
using Unity.VisualScripting;
using UnityEngine;

[UnitTitle("Enable UI")]
public class ShowUINode : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;
    [DoNotSerialize]
    public ControlOutput outputTrigger;
    [DoNotSerialize]
    public ValueInput Dot;
    [DoNotSerialize]
    public ValueInput Subtitles;
    [DoNotSerialize]
    public ValueInput History;
    [DoNotSerialize]
    public ValueInput Cutscene;
    [DoNotSerialize]
    public ValueInput Blur;
    private HideService showUI;

    protected override void Definition()
    {
        inputTrigger = ControlInput("inputTrigger", (flow) => { 
            showUI = Registry.Instance.Get<HideService>();
            showUI.Dot(flow.GetValue<bool>(Dot));
            showUI.Subtitles(flow.GetValue<bool>(Subtitles));
            showUI.Cutscene(flow.GetValue<bool>(Cutscene));
            showUI.History(flow.GetValue<bool>(History));
            showUI.Blur(flow.GetValue<bool>(Blur));
            
            return outputTrigger;
        });

        outputTrigger = ControlOutput("outputTrigger");
        Dot = ValueInput<bool>("Dot", false);
        Subtitles = ValueInput<bool>("Subtitles", false);
        History = ValueInput<bool>("History", false);
        Cutscene = ValueInput<bool>("Cutscene", false);
        Blur = ValueInput<bool>("Blur", false);
    }
}
