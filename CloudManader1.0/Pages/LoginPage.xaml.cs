﻿
namespace CloudManader1._0
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.DataContext = new LoginPageViewModel();
        }
    }
}
