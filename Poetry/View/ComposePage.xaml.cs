﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class ComposePage : ContentPage
	{
		 ComposeViewModel viewModel;


		public ComposePage(Poem poem)
		{
			InitializeComponent();

			viewModel = new ComposeViewModel(this);

			if(string.IsNullOrEmpty(poem.Id))
				viewModel.SelectedPoem = poem;
			BindingContext = viewModel;


		}

		protected override void OnAppearing()
		{
			base.OnAppearing();


		}
	}
}

