namespace AHWForm.View
{
    public interface IBidView : IMVPView
    {
        string Value { get; set; }
        decimal ActualValue { get; set; }
    }
}