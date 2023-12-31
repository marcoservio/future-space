﻿namespace FutureSpace.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Launch_Library_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Launch_Designator { get; set; }
        public string Type { get; set; }
        public virtual Orbit Orbit { get; set; }
    }
}