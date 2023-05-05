using System;
using System.Collections.Generic;
using DogFactsSamples.Models;
using DogFactsSamples.Data;
using Xamarin.Forms;


namespace DogFactsSamples
{
    public partial class App : Application
    {
        static DogFactsDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public static DogFactsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DogFactsDatabase();
                    prefillDatabase();

                }
                return database;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        static void prefillDatabase()
        {
            database.ClearAllAsync();
            List<Fact> items = new List<Fact>();
            items.Add(new Fact() { TheFact = "My name is Ashley.", ShortFact = "My name", ImgSrc = "name.jpg" });
            items.Add(new Fact() { TheFact = "Never ask a woman her age.", ShortFact = "My age", ImgSrc = "age.jpg" });
            items.Add(new Fact() { TheFact = "I like cats!", ShortFact = "I like", ImgSrc = "cat.jpg" });
            items.Add(new Fact() { TheFact = "I like rock climbing!", ShortFact = "I also like", ImgSrc = "rock.jpg" });
            items.Add(new Fact() { TheFact = "I like to learn!", ShortFact = "Another thing I like", ImgSrc = "learn.jpg" });
            database.InsertList(items);

        }
    }
}
