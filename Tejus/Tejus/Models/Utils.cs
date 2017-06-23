using System;
using System.Collections.Generic;
using System.Text;

namespace Tejus.Models
{
    public class TEJUSResultModel
    {
        public bool SuccessStatus { get; set; }
        public string SuccessMessage { get; set; }
        public bool ShowWarning { get; set; }
        public List<TEJUSErrorModel> ErrorList { get; set; }
    }
    public class TEJUSErrorModel
    {
        public string ErrorField { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
    }
    public class UserDetail
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
