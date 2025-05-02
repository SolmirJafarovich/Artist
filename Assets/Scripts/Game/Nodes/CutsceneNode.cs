using System;
using Unity.VisualScripting;
using UnityEngine;

[UnitTitle("Cutscene")]
public class CutsceneNode : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;
    [DoNotSerialize]
    public ControlInput onClick;
    [DoNotSerialize]
    public ControlOutput outputTrigger;
    [DoNotSerialize]
    public ValueInput SlidesFolder;
    private CutsceneService cutscene;

    protected override void Definition()
    {
        inputTrigger = ControlInput("inputTrigger", (flow) => { 
            cutscene = Registry.Instance.Get<CutsceneService>();
            cutscene.Init(flow.GetValue<string>(SlidesFolder));

            if(!cutscene.NextSlide())
                return outputTrigger;
            return null;
        });

        onClick = ControlInput("onClick", (flow) => { 
            if(!cutscene.NextSlide())
                return outputTrigger;
            return null;
        });

        outputTrigger = ControlOutput("outputTrigger");
        SlidesFolder = ValueInput<string>("SlidesFolder", string.Empty);
    }
}
