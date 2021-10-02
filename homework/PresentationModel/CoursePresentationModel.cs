using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace homework.PresentationModel
{
    public class CoursePresentationModel
    {
        private bool _isButtonSendEnable = false;
        private bool _isButtonShowSelectResultEnable = true;
        private const string TARGET = "checkBoxCol";
        private Model.Model _model;
        private HashSet<int> _courseSelectData;

        public CoursePresentationModel(Model.Model model)
        {
            _model = model;
            _courseSelectData = new HashSet<int>();
        }

        /// <summary>
        /// Get Course Data 
        /// </summary>
        /// <returns>Course Data</returns>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public List<ViewModel.Course> GetCourse(string url)
        {
            return _model.GetCourse(url);
        }

        /// <summary>
        /// btnSend status
        /// </summary>
        public bool IsButtonSendEnable()
        {
            return _isButtonSendEnable;
        }

        /// <summary>
        /// btnShowSelectResult status
        /// </summary>
        public bool IsButtonShowSelectResultEnable()
        {
            return _isButtonShowSelectResultEnable;
        }

        /// <summary>
        /// 紀錄當前畫面上checkbox的狀態
        /// </summary>
        /// <param name="index"></param>
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

            if (_courseSelectData.Count == 0)
            {
                _isButtonSendEnable = false;
            }
            else
            {
                _isButtonSendEnable = true;
            }
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
                foreach (int i in selectIndex)
                {
                    message += Convert.ToString(dataSource[i].Cells[ViewModel.CourseProperty.Number.ToString()].Value)
                        + Convert.ToString(dataSource[i].Cells[ViewModel.CourseProperty.Name.ToString()].Value)
                        + Environment.NewLine;
                }
            }
            return message;
        }

    }
}