using System.Windows;
using Jamesnet.Wpf.Controls;

namespace WpfExplorer.Main.UI.Views;

public class MainContent : JamesContent
{
    static MainContent()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MainContent),
            new FrameworkPropertyMetadata(typeof(MainContent)));
    }
}