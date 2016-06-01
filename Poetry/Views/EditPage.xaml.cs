using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class EditPage : ContentPage
	{
		EditViewModel ViewModel;
		public EditPage()
		{
			InitializeComponent();
			BindingContext = ViewModel = new EditViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Title = "Count : " + ViewModel.PoemList.Count.ToString();
		}
	}
}

