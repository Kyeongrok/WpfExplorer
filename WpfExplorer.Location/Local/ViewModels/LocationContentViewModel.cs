using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Mvvm;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Location.Local.ViewModels;

public partial class LocationContentViewModel : ObservableBase
{
    private readonly NavigatorService _navigatorService;
    
    // 뷰에 현재위치 값을 업데이트하기 위한 속성
    [ObservableProperty]
    private FileInfoBase _current;

    public LocationContentViewModel(NavigatorService navigatorService)
    {
        _navigatorService = navigatorService;
        _navigatorService.LocationChanged += _navigatorService_LocationChanged;
    }

    private void _navigatorService_LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        Current = e.Current;
    }
}