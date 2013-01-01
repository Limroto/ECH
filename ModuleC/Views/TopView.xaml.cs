using System.Windows.Controls;
using System.Windows.Media;
using ECH.ModuleC.ViewModels;
using Microsoft.Practices.Prism.Regions;

namespace ECH.ModuleC
{
	/// <summary>
	/// Interaction logic for TopView.xaml
	/// </summary>
	/// 
	[ViewSortHint("01")]
	public partial class TopView : UserControl
	{
	  private readonly TopViewModel _topViewModel;
	  
	  public TopView(TopViewModel topViewModel)
	  {
	    _topViewModel = topViewModel;
	    InitializeComponent();
	  }
  }
}
