using System;
using System.Collections.Generic;
using System.Text;
using Ballit.Core.Models;
using Ballit.Core.ViewModels;

namespace Ballit.Core.Mappers
{
    public class EntityMapper<TModel, TView> : MapperBase<TModel, TView>
        where TModel : Entity<long>, new()
        where TView : EntityView<long>,  new()
    {
        public override TModel ToDataModel(TView view)
        {
            return new TModel
            {
                Id = view.Id
            };
        }

        public override TView ToViewModel(TModel model)
        {
            return new TView
            {
                Id = model.Id
            };
        }
    }
}
