using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class ComposePage : ContentPage
	{
		public ComposeViewModel viewModel;
		public ComposePage(Poem poem)
		{
			InitializeComponent();

			viewModel = new ComposeViewModel();
			viewModel.SelectedPoem = poem;
			BindingContext = viewModel.SelectedPoem;


		}

		protected override void OnAppearing()
		{
			


			base.OnAppearing();

			this.PTitle.Text = viewModel.SelectedPoem.Title;
			this.PContent.Text = viewModel.SelectedPoem.Content;
			this.Author.Text = viewModel.SelectedPoem.Author;
			this.PDateCreated.Text = viewModel.SelectedPoem.DateCreated.ToString();

			Save.Clicked += (sender, e) => 
			{
				viewModel.SelectedPoem.Title = PTitle.Text;
				viewModel.SelectedPoem.Content = PContent.Text;
				viewModel.SelectedPoem.DateCreated = DateTime.Now;
				viewModel.SelectedPoem.Author = Author.Text;
				viewModel.db.SavePoem(viewModel.SelectedPoem);
			};

			Remove.Clicked += (sender, e) =>
			{
				if(viewModel.SelectedPoem.Id!=0)
					viewModel.db.DeletePoem(viewModel.SelectedPoem);
			};
		}
	}
}

