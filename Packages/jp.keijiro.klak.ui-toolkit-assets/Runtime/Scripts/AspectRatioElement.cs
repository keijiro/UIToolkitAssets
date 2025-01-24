using UnityEngine;
using UnityEngine.UIElements;

namespace Klak.UIToolkit {

// Fixed aspect ratio element
// Copy-pasted from UI Toolkit documentation
[UxmlElement]
public sealed partial class AspectRatioElement : VisualElement
{
    [UxmlAttribute("width")]
    public int RatioWidth
      { get => _ratioWidth;
        set { _ratioWidth = value; UpdateAspect(); } }

    [UxmlAttribute("height")]
    public int RatioHeight
      { get => _ratioHeight;
        set { _ratioHeight = value; UpdateAspect(); } }

    private int _ratioWidth = 16;
    private int _ratioHeight = 9;

    public AspectRatioElement()
    {
        RegisterCallback<GeometryChangedEvent>(UpdateAspectAfterEvent);
        RegisterCallback<AttachToPanelEvent>(UpdateAspectAfterEvent);
    }

    static void UpdateAspectAfterEvent(EventBase evt)
      => (evt.target as AspectRatioElement)?.UpdateAspect();

    private void ClearPadding()
    {
        style.paddingLeft = 0;
        style.paddingRight = 0;
        style.paddingBottom = 0;
        style.paddingTop = 0;
    }

    private void UpdateAspect()
    {
        var aspect = (float)RatioWidth / RatioHeight;
        var diff = resolvedStyle.width / resolvedStyle.height - aspect;

        if (RatioWidth <= 0.0f || RatioHeight <= 0.0f)
        {
            ClearPadding();
            return;
        }

        if (float.IsNaN(resolvedStyle.width)) return;
        if (float.IsNaN(resolvedStyle.height)) return;

        if (diff > 0.01f)
        {
            var w = (resolvedStyle.width - resolvedStyle.height * aspect) / 2;
            style.paddingLeft = w;
            style.paddingRight = w;
            style.paddingTop = 0;
            style.paddingBottom = 0;
        }
        else if (diff < -0.01f)
        {
            var h = (resolvedStyle.height - resolvedStyle.width / aspect) / 2;
            style.paddingLeft= 0;
            style.paddingRight = 0;
            style.paddingTop = h;
            style.paddingBottom = h;
        }
        else
        {
            ClearPadding();
        }
    }
}

} // namespace Klak.UIToolkit
