using CommunityToolkit.Mvvm.Input;
using ToDo_ListView.Models;

namespace ToDo_ListView.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}