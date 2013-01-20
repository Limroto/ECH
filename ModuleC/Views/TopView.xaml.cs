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
	  private readonly TopViewViewModel _topViewViewModel;
	  
	  public TopView(TopViewViewModel topViewViewModel)
	  {
	    _topViewViewModel = topViewViewModel;
	    InitializeComponent();
	  }
  }
}
