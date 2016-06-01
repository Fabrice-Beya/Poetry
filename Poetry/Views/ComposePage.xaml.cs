using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class ComposePage : ContentPage
	{
		ComposeViewModel ViewModel;
		Poem NewPoem;
		public ComposePage()
		{
			InitializeComponent();
			BindingContext = ViewModel = new ComposeViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Save.Clicked += (sender, e) => {
			
			};
		}
	}
}

