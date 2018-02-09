namespace AHWForm.View
{
    public interface ICreateCommentView:IMVPView
    {
        string Description { get; set; }
        string Rate { get; set; }
    }
}