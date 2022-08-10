using Models.DataModels;

namespace ViewModels
{
    public class ModelViewModel<TModel> : ViewModel
        where TModel : BaseModel, new()
    {
        protected TModel model;

        public ModelViewModel(TModel model)
        {
            this.model = model;
        }
    }
}
