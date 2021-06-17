using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXam.Common.Models
{
    public class WorkTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string StatusStr => Status ? "Completado" : "Pendiente";
    }
}
