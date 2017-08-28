using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ballit.Core.Extensions;
using Ballit.Core.Models;
using Ballit.Core.ViewModels;

namespace Ballit.Core.Mappers
{
    public class PostMapper : EntityMapper<Post, PostView>
    {
        public override Post ToDataModel(PostView view)
        {
            var model = base.ToDataModel(view);

            return model;
        }

        public override PostView ToViewModel(Post model)
        {
            var view = base.ToViewModel(model);
            view.Title = model.Title;
            view.Text = model.Text;
            view.ThumbUrl = model.ThumbUrl;
            view.Url = model.Url;
            view.UrlTitle = model.UrlTitle;
            //view.Score = model.PostScore();
            //view.Order = model.OrderScore();
            view.NumberOfComments = model.Comments?.Count() ?? 0;
            return view;
        }
    }
}
