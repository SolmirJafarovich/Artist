using System;
using Unity.VisualScripting;
using UnityEngine;

[UnitTitle("Show subtitle")]
public class SubtitlesNode : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;

    [DoNotSerialize]
    public ControlOutput outputTrigger;

    [DoNotSerialize]
    public ValueInput SubtitleKey;

    private SubtitlesService subtitles;

    private void ShowSubtitles(string Key)
    {
        subtitles = Registry.Instance.Get<SubtitlesService>();
        subtitles.ShowSubtitleByKey(Key);
    }

    protected override void Definition()
    {
        inputTrigger = ControlInput(
            "inputTrigger",
            (flow) =>
            {
                ShowSubtitles(flow.GetValue<string>(SubtitleKey));
                return outputTrigger;
            }
        );
        outputTrigger = ControlOutput("outputTrigger");
        SubtitleKey = ValueInput<string>("SubtitleKey", string.Empty);
    }
}
