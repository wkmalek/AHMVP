namespace AHWForm.View
{
    public interface ICreateCommentView : IMyView
    {
        string Description { get; set; }
        string Rate { get; }
    }
}