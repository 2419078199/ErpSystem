using System;

namespace Model.Dtos.EditDto
{
    public class AuRecordEditDto
    {
        public int Id { get; set; }
        public int? SourceType { get; set; }
        public int? SourceId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateDesc { get; set; }
        public int? ApproverId { get; set; }
        public DateTime? ApproveTime { get; set; }
        public DateTime? ApproveDesc { get; set; }
        public string ApproveReult { get; set; }
        public string Remark { get; set; }
    }
}