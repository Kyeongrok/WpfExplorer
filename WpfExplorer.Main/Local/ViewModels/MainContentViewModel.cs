using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Main.Local.ViewModels;

/// MainContent 뷰의 ViewModel
/// - 트리뷰에 표시할 루트 폴더 목록 관리
/// - 폴더 선택 시 하위 디렉토리 로드
public partial class MainContentViewModel : ObservableBase
{
    // FileService: 파일/폴더 탐색 기능 제공 (DI로 주입)
    private readonly FileService _fileService;
    private readonly NavigatorService _navigatorService;

    // 트리뷰의 루트 노드 목록 (Download, Documents, Pictures, 드라이브들)
    public List<FolderInfo> Roots { get; init; }
    public ObservableCollection<FolderInfo> Files { get; init; }

    /// <summary>
    /// 생성자: FileService를 주입받아 루트 노드 생성
    /// </summary>
    public MainContentViewModel(FileService fileService, NavigatorService navigatorService)
    {
        _fileService = fileService;
        _navigatorService = navigatorService;
        _navigatorService.LocationChanged += _navigatorService_LocationChanged;

        // 루트 노드 생성 (특수 폴더 + 드라이브 목록)
        Roots = _fileService.GenerateRootNodes();
        Files = new();
    }

    private void _navigatorService_LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        List<FolderInfo> source = GetDirectoryItems(e.Current.FullPath);

        Files.Clear();
        Files.AddRange(source);
    }
    
    
    private List<FolderInfo> GetDirectoryItems(string fullPath)
    {
        List<FolderInfo> items = new();

        string[] dirs = Directory.GetDirectories(fullPath);
        foreach (string path in dirs)
        {
            items.Add(new FolderInfo { FullPath = path });
        }

        string[] files = Directory.GetFiles(fullPath);
        foreach (string path in files)
        {
            items.Add(new FolderInfo { FullPath = path });
        }
        return items;
    }

    /// <summary>
    /// 폴더 선택 시 호출되는 커맨드
    /// - FolderTreeView의 SelectionCommand에 바인딩됨
    /// - 선택된 폴더의 하위 디렉토리를 로드
    /// </summary>
    [RelayCommand]
    private void FolderChanged(FolderInfo folderInfo)
    {
        _fileService.RefreshSubdirectories(folderInfo);
        _navigatorService.ChangeLocation(folderInfo);
    }

}