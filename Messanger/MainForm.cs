using Messanger.Dtos;
using Messanger.Interfaces;
using Messanger.Models;
using Messanger.Repositories;
using System.Data.SqlClient;

namespace Messanger
{
    public partial class MainForm : Form
    {
        public string CurrentUser;
        private readonly List<User> _users;
        private readonly UserDto _user;
        private readonly IUserRepository _userRepository = new UserRepository();

        public MainForm()
        {
            _users = new List<User>();
            _user = new UserDto();
            InitializeComponent();
        }

        private async void registerBtn_Click(object sender, EventArgs e)
            {
            _user.FirstName = firstNameTb.Text;
            _user.LastName = lastNameTb.Text;
            _user.Email = emailTb.Text;
            _user.PhoneNumber = phoneNumberTb.Text;
            _user.UserName = userNameTb.Text;

            User user = await _userRepository.GetAsync(_user.Email);

            if (user.Id == 0)
            {
                int result = await _userRepository.CreateAsync(_user);

                if (result > 0)
                {
                    CurrentUser = _user.UserName;
                    MessagePage messagePage = new MessagePage();
                    messagePage.Show();
                    this.Hide();
                }
                else
                {
                    wrongRegisterLb.Text = "Register not successfully !";
                    wrongRegisterLb.ForeColor = Color.Red;
                }

            }
            else
            {
                wrongRegisterLb.Text = "Registered with this email and username !";
                wrongRegisterLb.ForeColor = Color.Red;
            }
        }
    }
}
