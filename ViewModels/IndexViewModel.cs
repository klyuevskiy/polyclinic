using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class IndexViewModel<TModel, TViewModel> : ViewModel
        where TModel : BaseModel, new()
        where TViewModel : ModelViewModel<TModel>
    {
        private readonly Func<TModel, TViewModel> constructor;
        protected ObservableCollection<TViewModel> collection;

        public IndexViewModel(Func<TModel, TViewModel> Constructor)
        {
            constructor = Constructor;
            collection = new ObservableCollection<TViewModel>();
        }

        protected void Add(TModel model)
        {
            collection.Add(constructor(model));
        }

        protected void Build(IEnumerable<TModel> models)
        {
            collection.Clear();

            foreach (var item in models)
            {
                Add(item);
            }
        }
    }
}
