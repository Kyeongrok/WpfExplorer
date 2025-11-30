using System;
using System.IO;

namespace WpfExplorer.Support.Local.Helpers;

public class DirectoryManager
{
    public string DownloadDirectroy { get; init; }
    public string DocumentsDirectroy { get; init; }
    public string PicturesDirectroy { get; init; }
    
    public DirectoryManager()
    {
        var userPath = Environment.GetFolderPath(
            Environment.SpecialFolder.UserProfile
        );

        DownloadDirectroy = Path.Combine(userPath, "Downloads");
        DocumentsDirectroy = Environment.GetFolderPath(
            Environment.SpecialFolder.MyDocuments
        );

        PicturesDirectroy = Environment.GetFolderPath(
            Environment.SpecialFolder.MyPictures
        );
        
    }
}