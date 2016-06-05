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

			viewModel = new ComposeViewModel();
			if(poem.Id!=0)
				viewModel.SelectedPoem = poem;



		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (BindingContext == null)
			{
				BindingContext = viewModel;
			}

		}
	}
}

