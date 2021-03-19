using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp2 {
  public partial class MainWindow : Window, INotifyPropertyChanged {

    public MainWindow() {
      DataContext = this;
      InitializeComponent();
    }

    private Visibility dialogHostContextTextVisibility = Visibility.Collapsed;
    public Visibility DialogHostContextTextVisibility {
      get => dialogHostContextTextVisibility;
      set {
        dialogHostContextTextVisibility = value;
        OnPropertyChanged();
      }
    }

    private bool isDialogOpen = false;
    public bool IsDialogOpen {
      get => isDialogOpen;
      set {
        isDialogOpen = value;
        DialogHostContextTextVisibility = value ? Visibility.Visible : Visibility.Collapsed;
        OnPropertyChanged();
      }
    }

    private void OpenDialog(object _1, RoutedEventArgs _2) =>
      IsDialogOpen = true;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
  }
}