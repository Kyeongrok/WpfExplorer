using System.Windows;
using Jamesnet.Wpf.Controls;

namespace WpfExplorer.Location.UI.Views;

public class LocationContent : JamesContent
{
    static LocationContent()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(LocationContent), 
            new FrameworkPropertyMetadata(typeof(LocationContent)));
    }
} 