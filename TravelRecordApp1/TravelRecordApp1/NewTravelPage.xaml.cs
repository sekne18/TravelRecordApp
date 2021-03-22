using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp1.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>(); //Creates Table
                int rows = conn.Insert(post); //Inserts into db

                if (rows > 0) // if there was any inserted rows...
                    DisplayAlert("Success", "Experience succesfully inserted", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
            }

        }
    }
}