using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO2._6.Models
{
    public partial class Inimene
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public Nullable<int> Vanus { get; set; }
    }
}