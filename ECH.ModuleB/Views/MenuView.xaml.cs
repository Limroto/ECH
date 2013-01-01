using System.Windows.Controls;
using ECH.ModuleB.ViewModels;
using Microsoft.Practices.Prism.Regions;

namespace ECH.ModuleB.Views
{
	/// <summary>
	/// Interaction logic for MenuView.xaml
	/// </summary>
	[ViewSortHint("01")]
	public partial class MenuView : UserControl
	{
	  private readonly MenuViewModel _menuViewModel;

	  public MenuView(MenuViewModel menuViewModel)
		{
		  _menuViewModel = menuViewModel;
		  InitializeComponent();
		}
	}
}
