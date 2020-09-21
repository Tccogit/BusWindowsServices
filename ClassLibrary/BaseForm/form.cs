using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// وضعیت فرم به لحاظ درج یا ویرایش یا تایید اطلاعات فرم
    /// </summary>
    public enum JFormState
    {
        Insert,
        Update,
        Confirm,
        ReadOnly,
        Close,
        None,
        Delete,
    }
}
