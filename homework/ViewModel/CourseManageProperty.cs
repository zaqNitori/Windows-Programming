using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.ViewModel
{
    public enum CourseManageAction
    {
        None,
        Edit,
        Add
    }

    public static class CourseManageProperty
    {
        public const int COLUMN_WIDTH = 40;
        public const int FIFTY_SEVEN_NUMBER = 57;
        public const int FORTY_EIGHT_NUMBER = 48;
        public const int EIGHT_NUMBER = 8;
        public const int TEN_NUMBER = 10;

        public const char ZERO = '0';
        public const char NINE = '9';
        public const char NEW_LINE = '\n';
        public const char SPACE = ' ';

        public const string COLUMN_NAME = "courseHour";
        public const string COLUMN_TITLE = "節數";

        public const string ERROR_MESSAGE_NOT_NUMBER = "請輸入整數數字";
        public const string ERROR_MESSAGE_COURSE_NUMBER_CONFLICT = "課號重複，請重新輸入。";

        public const string COURSE_MANAGE_TAB_PAGE_TITLE = "課程管理";
        public const string CLASS_MANAGE_TAB_PAGE_TITLE = "班級管理";
        public const string COURSE_ADD_GROUP_BOX_TITLE = "新增課程";
        public const string COURSE_EDIT_GROUP_BOX_TITLE = "編輯課程";
        public const string BUTTON_SAVE_TEXT = "儲存";
        public const string BUTTON_ADD_TEXT = "新增";

        public const string BINDING_READ_ONLY_STATUS = "ReadOnly";
        public const string BINDING_ENABLED_STATUS = "Enabled";
        public const string BINDING_TEXT = "Text";
        public const string SOURCE_COMBO_BOX_ENABLED = "IsCourseComboBoxEnabled";
        public const string SOURCE_READ_ONLY_STATUS = "IsCourseEditReadOnly";
        public const string SOURCE_GROUP_BOX_TITLE = "GroupBoxTitle";
        public const string SOURCE_BUTTON_CONFIRM_ENABLED = "IsButtonConfirmEnabled";
        public const string SOURCE_BUTTON_ADD_ENABLED = "IsButtonAddCourseEnabled";
        public const string SOURCE_BUTTON_CONFIRM_TEXT = "ButtonConfirmText";
    }

}
