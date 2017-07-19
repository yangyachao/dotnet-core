using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public partial class WfSchemeContent
    {
        public string Id { get; set; }
        public string WfschemeInfoId { get; set; }
        public string SchemeVersion { get; set; }
        public JObject SchemeContent { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
    }
}
