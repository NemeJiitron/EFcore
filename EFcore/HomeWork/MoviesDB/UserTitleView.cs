using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.HomeWork.MoviesDB
{
    public class UserTitleView
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int TitleId { get; set; }
        public string TitleName { get; set; }

    }
}
