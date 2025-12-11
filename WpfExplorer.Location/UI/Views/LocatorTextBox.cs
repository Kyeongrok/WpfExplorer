using System.Windows;
using System.Windows.Controls;

namespace WpfExplorer.Location.UI.Views;

public class LocatorTextBox : TextBox
{
    static LocatorTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LocatorTextBox),
                new FrameworkPropertyMetadata(typeof(LocatorTextBox)));
        }
}