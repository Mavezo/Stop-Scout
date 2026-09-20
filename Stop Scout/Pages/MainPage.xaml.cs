using Stop_Scout.Models;
using Stop_Scout.PageModels;

namespace Stop_Scout.Pages
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainPageModel model)
		{
			InitializeComponent();
			BindingContext = model;
		}
	}
}