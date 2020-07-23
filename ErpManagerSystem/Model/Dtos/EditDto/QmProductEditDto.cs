using System;

namespace Model.Dtos.EditDto
{
    public class QmProductEditDto
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int? TaskId { get; set; }
        public DateTime? QmDate { get; set; }
        public int? Result { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public string Pic { get; set; }
        public string Remark { get; set; }
    }
}