using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using homework.Model;
using homework.ViewModel;

namespace homework.PresentationModel
{
    public class CourseSelectingPresentationModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private CourseModel _courseModel;
        private HashSet<int> _courseSelectData;

        public CourseSelectingPresentationModel(CourseModel courseModel)
        {
            _courseModel = courseModel;
            _courseSelectData = new HashSet<int>();
            IsButtonSendEnable = false;
            IsButtonShowSelectResultEnable = true;
        }

        public bool IsButtonSendEnable
        {
            get; set;
        }

        public bool IsButtonShowSelectResultEnable
        {
            get; set;
        }

        /// <summary>
        /// GridCheckBox點擊事件trigger 
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        void NotifyObserver()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        /// <summary>
        /// Get Course Data 
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public List<Course> GetCourse()
        {
            return _courseModel.GetCourse();
        }

        /// <summary>
        /// 紀錄當前畫面上checkbox的狀態
        /// </summary>
        public void SetCourseCheckBoxStatus(int index)
        {
            if (_courseSelectData.Contains(index))
            {
                _courseSelectData.Remove(index);
            }
            else
            {
                _courseSelectData.Add(index);
            }

            IsButtonSendEnable = (_courseSelectData.Count == 0) ? false : true;
            NotifyObserver();
        }

        /// <summary>
        /// 取得畫面上選取到的資料內容
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public string GetSelectedResult(DataGridViewRowCollection dataSource)
        {
            string message = string.Empty;
            List<int> selectIndex;
            
            if (_courseSelectData.Count > 0)
            {
                selectIndex = _courseSelectData.ToList();
                selectIndex.Sort();
                foreach (int i in selectIndex)
                {
                    message += Convert.ToString(dataSource[i].Cells[CourseProperty.Number.ToString()].Value)
                        + Convert.ToString(dataSource[i].Cells[CourseProperty.Name.ToString()].Value)
                        + Environment.NewLine;
                }
            }
            return message;
        }

        /// <summary>
        /// 取得所有班級名稱
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public List<string> GetAllDepartment()
        {
            return _courseModel.GetAllDepartment();
        }

        /// <summary>
        /// 用班級名稱取得課表
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public List<Course> GetCourseByDepartmentName(string name)
        {
            return _courseModel.GetCourseByDepartmentName(name);
        }

    }
}