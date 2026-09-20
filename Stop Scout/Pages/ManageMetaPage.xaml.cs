namespace Stop_Scout.Pages
{
	public partial class ManageMetaPage : ContentPage
	{
		public ManageMetaPage(ManageMetaPageModel model)
		{
			InitializeComponent();
			BindingContext = model;
		}
	}
}