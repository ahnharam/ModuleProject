using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ModuleProject.GoogleSheet
{
    public class GoogleSheetViewModel : BindableBase
    {
        private readonly IGoogleSheetsService _sheetsService;

        public ObservableCollection<string> Rows { get; } = new ObservableCollection<string>();

        public DelegateCommand LoadCommand { get; }

        public GoogleSheetViewModel(IGoogleSheetsService sheetsService)
        {
            _sheetsService = sheetsService;
            LoadCommand = new DelegateCommand(async () => await LoadDataAsync());
        }

        private async Task LoadDataAsync()
        {
            Rows.Clear();
            var data = await _sheetsService.ReadSheetAsync();
            foreach (var row in data)
            {
                Rows.Add(string.Join(", ", row));
            }
        }
    }
}
