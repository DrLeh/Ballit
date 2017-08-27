using System;
using System.Collections.Generic;
using System.Text;

namespace Ballit.Core.Mappers
{
    public abstract class MapperBase<TModel, TView>
        where TModel : class, new()
        where TView : class, new()
    {
        public abstract TModel ToDataModel(TView view);
        public abstract TView ToViewModel(TModel model);
    }
}
