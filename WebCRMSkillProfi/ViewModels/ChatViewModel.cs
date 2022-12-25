using System.ComponentModel.DataAnnotations;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.ViewModels
{
    public class ChatViewModel
    {
        //[Required]
        [Display(Name = "Ваш чат")]
        public string _NameChat { get; set; }

        //[Required]
        [Display(Name = "Сообщение")]
        public string _MessangeChat { get; set; }
        //
        //[Required]
        //[Display(Name = "Сообщение..")]
        public string _TextNewMessange { get; set; }
        //основная модель
        public string _Id { get; set; }
        public string _TimeRequest { get; set; }
        public Messange _TextMessange { get; set; }
        public string _EmailSender { get; set; }
        public string _UserRecipientMess { get; set; }
        public string _imagePath { get; set; }
        //user
        public User _User { get; set; }
        //public string _Email { get; set; }
    }
}
