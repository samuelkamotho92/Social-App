using Social_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_App.Service.Iservice
{
    public interface IComment
    {
        Task<List<CommentModel>> GetComment(int id);
    }
}
