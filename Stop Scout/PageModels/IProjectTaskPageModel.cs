using CommunityToolkit.Mvvm.Input;
using Stop_Scout.Models;

namespace Stop_Scout.PageModels
{
	public interface IProjectTaskPageModel
	{
		IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
		bool IsBusy { get; }
	}
}