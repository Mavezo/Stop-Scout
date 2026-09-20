namespace Stop_Scout.Pages
{
	public partial class TaskDetailPage : ContentPage
	{
		public TaskDetailPage(TaskDetailPageModel model)
		{
			InitializeComponent();
			BindingContext = model;
		}
	}
}