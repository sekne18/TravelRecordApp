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
	public partial class PostDetailPage : ContentPage
	{
        Post selectedPost;
		public PostDetailPage (Post selectedPost)
		{
			InitializeComponent ();

            this.selectedPost = selectedPost;

            experienceEntry.Text = selectedPost.Experience;
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>(); //Creates Table
                int rows = conn.Update(selectedPost);

                if (rows > 0) // if there was any inserted rows...
                    DisplayAlert("Success", "Experience succesfully updated", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be updated", "Ok");
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>(); //Creates Table
                int rows = conn.Delete(selectedPost);

                if (rows > 0) // if there was any inserted rows...
                    DisplayAlert("Success", "Experience succesfully deleted", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
            }
        }
    }
}