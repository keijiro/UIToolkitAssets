using UnityEngine;
using UnityEngine.UIElements;

namespace Klak.UIToolkit {

[UxmlElement]
public partial class ClampedIntegerField : IntegerField
{
    [UxmlAttribute] public int lowValue { get; set; } = 0;
    [UxmlAttribute] public int highValue { get; set; } = 100;

    public override void SetValueWithoutNotify(int newValue)
      => base.SetValueWithoutNotify(Mathf.Clamp(newValue, lowValue, highValue));
}

} // namespace Klak.UIToolkit
