using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropertyManager.IRepo;
using PropertyManager.Models.PropertyModels;
using PropertyManager.Models.ViewModel;
using PropertyManager.Repo;

namespace PropertyManager.Logic
{
    public class NoticesLogic
    {
        
            private INoticeRepo _repo;

            public NoticesLogic()
            {
                //  _repo = new NoticeRepo();
            }

            public List<ViewModelPropertyPropertyPhoto> FindNotices(ViewModelFilterNotice filterPattern)
            {
                IQueryable<Property> properties = _repo.GetAll();

                return new List<ViewModelPropertyPropertyPhoto>();
            }
        }
    }
