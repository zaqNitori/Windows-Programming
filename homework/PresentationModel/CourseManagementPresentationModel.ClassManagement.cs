using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Manager;
using homework.ViewModel;

namespace homework.PresentationModel
{
    partial class CourseManagementPresentationModel
    {
        /// <summary>
        /// 取得所有課程名稱
        /// </summary>
        public List<DataItem> GetAllClassName()
        {
            return _courseManageModel.GetClassNameAsItem();
        }
    }
}
