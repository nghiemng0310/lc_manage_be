using System.ComponentModel;
using System.Runtime.Serialization;

namespace lcManage.Models
{
    public enum StatusEnum
    {
        [Description("Hoạt động")]
        [EnumMember(Value = "ACTIVE")]
        ACTIVE = 0,

        [Description("Ngưng hoạt động")]
        [EnumMember(Value = "INACTIVE")]
        INACTIVE = 1,

    }
}
