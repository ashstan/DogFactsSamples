using System;
using System.Collections.Generic;

namespace DogFactsSamples
{
    public class MeFactData
    {
        public MeFactData()
        {
        }
        public static IEnumerable<MeFactData> All { private set; get; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string ImgSrc { get; set; }
        static MeFactData()
        {
            List<MeFactData> all = new List<MeFactData>();
            all.Add(new MeFactData() { TheFact = "My name is Ashley.", ShortFact = "My name", ImgSrc = "name.jpg" });
            all.Add(new MeFactData() { TheFact = "Never ask a woman her age.", ShortFact = "My age", ImgSrc = "age.jpg" });
            all.Add(new MeFactData() { TheFact = "I like cats!", ShortFact = "I like", ImgSrc = "cat.jpg" });
            all.Add(new MeFactData() { TheFact = "I like rock climbing!", ShortFact = "I also like", ImgSrc = "rock.jpg" });
            all.Add(new MeFactData() { TheFact = "I like to learn!", ShortFact = "Another thing I like", ImgSrc = "learn.jpg" });
            All = all;

        }
    }
}