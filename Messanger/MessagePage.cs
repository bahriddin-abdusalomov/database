using Messanger.Dtos;
using Messanger.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;

namespace Messanger
{
    public partial class MessagePage : Form
    {
        private readonly MessageDto _message;
        private readonly MainForm _user;
        private readonly IUserRepository _userRepository;
        public MessagePage()
        {
            InitializeComponent();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            User user = _userRepository.GetAsync();
            _message.MyUserName = _user.CurrentUser;
            if (toWhomTb.Text != null) _message.UserName = toWhomTb.Text;
            if (messageTb.Text != null) _message.Messages = messageTb.Text;

        }
    }
}
