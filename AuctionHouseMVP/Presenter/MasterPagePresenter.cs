using AHWForm.View;

namespace AHWForm.Presenter
{
    public class MasterPagePresenter
    {
        readonly IMasterPageModel _pModel;
        readonly IMasterPageView _pView;

        public MasterPagePresenter(IMasterPageModel PModel, IMasterPageView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }

        internal void PopulateMasterPage()
        {
            _pView.tv = _pModel.LoadCategories();
        }
    }
}