using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class TaskHartBeat
    {
        [Required(ErrorMessage = "任务编号不能为空"), MaxLength(50, ErrorMessage = "任务编号不能超过50个字符")]
        public string TaskId { get; set; }
    }
}