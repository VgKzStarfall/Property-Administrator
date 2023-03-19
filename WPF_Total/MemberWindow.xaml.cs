using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess.Repos;
using DataAccess.DataAccess;

namespace zPage
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        MemberRepository memberRepo;
        string searchMem;
        public MemberWindow(MemberRepository memberRepository)
        {
            InitializeComponent();
            memberRepo = memberRepository;
            LoadData();
            searchType.SelectedValue = "CompanyName";
            searchMem = "CompanyName";
        }
        public void LoadData()
        {
            dg.ItemsSource = memberRepo.GetMember();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUpdateMember(false, -1);
            window.Closing += AddUpdateWindow_Closing;
            window.ShowDialog();
        }
        private void AddUpdateWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Member? item = dg.SelectedItem as Member;
            if (item != null)
            {
                var window = new AddUpdateMember(true, item.MemberId);
                window.Closing += AddUpdateWindow_Closing;
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Choose A Member To Update");
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Member? item = dg.SelectedItem as Member;
            if (item != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete this member?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    memberRepo.DeleteMember(item.MemberId);
                }
                MessageBox.Show("Delete Successfully");
            }
            else
            {
                MessageBox.Show("Please Choose A Member To Delete");
            }
            LoadData();
        }

        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Please Choose A Member To View Details");
            }
            else
            {
                Member? p = dg.SelectedItem as Member;
                if (p.MemberId != 0)
                {
                    Member mem = memberRepo.GetMemberByID(p.MemberId);
                    var window = new DetailMember(mem);
                    window.Closing += AddUpdateWindow_Closing;
                    window.ShowDialog();
                }
            }
        }
        private void searchType_DropDownClosed(object sender, EventArgs e)
        {
            searchMem = searchType.Text;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if("CompanyName".Equals(searchMem))
            {
                dg.ItemsSource = memberRepo.GetListSearchByName(txtSearch.Text);
            } else if ("City".Equals(searchMem))
            {
                dg.ItemsSource = memberRepo.GetListSearchByCity(txtSearch.Text);
            }
            else if ("Country".Equals(searchMem))
            {
                dg.ItemsSource = memberRepo.GetListSearchByCountry(txtSearch.Text);
            }
        }
    }
}
