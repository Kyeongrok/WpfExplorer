using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfExplorer.Support.Local.Models;

public partial class FolderInfo : FileInfoBase
{
    [ObservableProperty] private bool _isFolderExpanded;
    [ObservableProperty] private bool _isFolderSelected;
    
    public ObservableCollection<FolderInfo> Children { get; set; }
}