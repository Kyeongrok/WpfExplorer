using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Main.Local.ViewModels;

public class MainContentViewModel
{
    public ICommand FolderChangedCommand { get; init; }
    public List<FolderInfo> Roots { get; init; }

    public MainContentViewModel(FileService _fileService)
    {
        FolderChangedCommand = new RelayCommand<FolderInfo>(FolderChanged);
            Roots = _fileService.GenerateRootNodes();
    }
    
    private void FolderChanged(FolderInfo folderInfo)
    {
        MessageBox.Show($"Selected: {folderInfo.Name}");
    }
        
}