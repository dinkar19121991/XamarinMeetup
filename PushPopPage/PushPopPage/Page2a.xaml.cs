using System;
using Xamarin.Forms;

namespace PushPopPage
{
	public partial class Page2a : ContentPage
	{
		public Page2a ()
		{
			InitializeComponent ();
		}

		async void OnNextPageButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new Page3 ());
		}

		async void OnPreviousPageButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}
	}
}
