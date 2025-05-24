using UnityEngine;
using UnityEngine.UIElements;

namespace Klak.UIToolkit {

[UxmlElement]
public partial class ClampedFloatField : FloatField
{
    [UxmlAttribute] public float lowValue { get; set; } = 0;
    [UxmlAttribute] public float highValue { get; set; } = 100;

    public override void SetValueWithoutNotify(float newValue)
      => base.SetValueWithoutNotify(Mathf.Clamp(newValue, lowValue, highValue));
}

} // namespace Klak.UIToolkit
