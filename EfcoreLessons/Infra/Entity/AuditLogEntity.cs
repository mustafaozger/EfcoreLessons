using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfcoreLessons.Infra.Entity.Base;

namespace EfcoreLessons.Infra.Entity
{
    public class AuditLogEntity:BaseEntity
    {
        public Guid UserId { get; set; }
        public string Operation { get; set; }
        public string TableName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}