﻿using System;
using SQLite;

namespace DogFactsSamples.Models
{
    public class Fact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string ImgSrc { get; set; }
    }
}
