using System;
using System.Collections.Generic;

namespace cleanCodeRuleta.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int? Number { get; set; }
        public int? Money { get; set; }
        public int? RadomNumber { get; set; }
        public int? Result { get; set; }
        public string Color { get; set; }
    }
}
