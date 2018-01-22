using UnityEngine;
using System.Collections;

public class FlashingAlways : HighlighterController
{

    public Color flashingStartColor = Color.blue;
    public Color flashingEndColor = Color.cyan;

    protected override void Start()
    {
        base.Start();
        h.FlashingOn(flashingStartColor, flashingEndColor);
    }

    void Update()
    {
        h.FlashingOn(flashingStartColor, flashingEndColor);
    }
}
