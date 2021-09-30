using System;
using System.Collections.Generic;

namespace MindVelleyCricketAcademyAPI.Models
{
    public partial class PlayerTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int MatchPlayed { get; set; }
        public int? RunScored { get; set; }
        public int? Wickets { get; set; }
        public int? OutOnDuck { get; set; }
        public string TypeOfPlayer { get; set; }
    }
}
