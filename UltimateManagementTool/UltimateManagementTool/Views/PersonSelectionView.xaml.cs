using System.Windows.Controls;

namespace UltimateManagementTool.Views
{
    using UltimateManagementTool.ViewModels;

    /// <summary>
    /// Interaction logic for PersonSelectionView.xaml
    /// </summary>
    public partial class PersonSelectionView : UserControl
    {
        public PersonSelectionView()
        {
            this.InitializeComponent();
            this.DataContext = new PersonSelectionViewModel();
        }
    }
}
