using Messanger.Interfaces;
using Messanger.Models;
using Messanger.Repositories;
using System.Data.SqlClient;

namespace Messanger
{
    public partial class MainForm : Form
    {
        private readonly List<User> _users;
        private readonly User _user;
        private readonly IUserRepository _userRepository = new UserRepository();
        
        public MainForm()
        {
            _users = new List<User>();
            _user = new User();
            InitializeComponent();
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            _user.FirstName = firstNameTb.Text;
            _user.LastName = lastNameTb.Text;
            _user.Email = emailTb.Text;
            _user.PhoneNumber = phoneNumberTb.Text;

            User user = await _userRepository.GetByIdAsync(_user.Email);

            if (user is null)
            {
                int result = await _userRepository.CreateAsync(user);

                if (result > 0)
                {
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
        }
    }
}
