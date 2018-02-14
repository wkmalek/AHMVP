namespace AHWForm.View
{
    public interface IBidView:IMyView
    {
        string Value { get; set; }
        decimal ActualValue { get; set; }
    }
}