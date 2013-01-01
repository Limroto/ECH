using System.Windows.Controls;
using ECH.ModuleA.ViewModels;
using Microsoft.Practices.Prism.Regions;

namespace ECH.ModuleA.Views
{
	/// <summary>
	/// Interaction logic for SettingsView.xaml
	/// </summary>
	[ViewSortHint("02")]
	public partial class SettingsView : UserControl
	{
	  private readonly SettingsViewModel _settingsViewModel;

	  public SettingsView(SettingsViewModel settingsViewModel)
		{
		  _settingsViewModel = settingsViewModel;
		  InitializeComponent();
		}
	}
}
