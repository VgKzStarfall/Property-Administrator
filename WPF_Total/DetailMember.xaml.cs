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
using DataAccess.DataAccess;
using DataAccess.Repos;

namespace zPage
{
    /// <summary>
    /// Interaction logic for DetailMember.xaml
    /// </summary>
    public partial class DetailMember : Window
    {
        Member mem;
        MemberRepository memberRepository = new MemberRepository();
        public DetailMember(Member member)
        {
            InitializeComponent();
            mem = member;
            LoadData();
        }
        private void LoadData()
        {
            if (mem != null)
            {
                lbName.Content = mem.CompanyName;
                lbCity.Content = mem.City;
                lbCountry.Content = mem.Country;
                lbEmail.Content = mem.Email;
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUpdateMember(true, mem.MemberId);
            window.Closing += ReloadData;
            window.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete this member?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                memberRepository.DeleteMember(mem.MemberId);
                MessageBox.Show("Delete Successfully");
            }
            this.Close();
        }
        private void ReloadData(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mem = memberRepository.GetMemberByID(mem.MemberId);
            LoadData();
        }
    }
}
