using Prism.Mvvm;

/// .Net 8 버전 프로젝트
namespace ModuleProject.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            
        }
    }
}
