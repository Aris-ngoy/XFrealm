using MongoDB.Bson;
using Realms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFrealm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            var realm = Realm.GetInstance();

            realm.Write(() =>
            {
                realm.Add(new Guitar()
                {
                    Make = "Gibson",
                    Model = "Les Paul Custom",
                    Price = 649.99,
                    Owner = "N. Young"
                });
            });

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }

    public class Guitar : RealmObject
    {
        [PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public double Price { get; set; }

        public string Owner { get; set; }
    }


}
