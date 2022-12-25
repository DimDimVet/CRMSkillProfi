using CRMSkillProfiBotTelegram.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CRMSkillProfiBotTelegram.Models
{
    public class LogicBot
    {
        private static IUser _defUser = new User { UserName = Option.UserName, Email = Option.Email };
        //
        private static LogicModel<User> _userLogic = new LogicModel<User>(Option.PathUser);
        private static LogicModel<Messange> _messangeLogic = new LogicModel<Messange>(Option.PathMessange);

        private static ObservableCollection<User> _userGet;
        private static ObservableCollection<Messange> _messangeGet;

        private static TelegramBotClient _bot = new TelegramBotClient(Option.BotToken);
        private static ReceiverOptions receiverOptions;
        private static ITelegramBotClient _currentBotClient;

        public static void BotStart()
        {
            receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage
                }
            };
            _bot.StartReceiving(UpdateHandler, PollingErrorHandler, receiverOptions);
        }

        private static async Task PollingErrorHandler(ITelegramBotClient _botClient, Exception _exception, CancellationToken _argNull)
        {
            MessageTelegram _messTel = new MessageTelegram();
            await SendMessageAsync(_messTel, Option.CurrentUserHello);
        }

        private static async Task UpdateHandler(ITelegramBotClient _botClient, Update _update, CancellationToken _argNull)
        {
            _currentBotClient = _botClient;
            MessageTelegram _messTel;
            if (_update.Type == UpdateType.Message)
            {
                if (_update.Message.Type == MessageType.Text)
                {
                    _messTel = new MessageTelegram
                    {
                        IdChat = _update.Message.Chat.Id,
                        FirstName = _update.Message.Chat.FirstName,
                        TextMessange = _update.Message.Text
                    };

                    string _statusConnect = await ControlUser(_messTel);
                    if (_statusConnect == "New")
                    {
                        SaveMessange(_messTel);
                        await SendMessageAsync( _messTel, Option.CurrentUserHello);
                    }
                    else if(_statusConnect == "Old")
                    {
                        SaveMessange(_messTel);
                        await SendMessageAsync( _messTel, Option.CurrentUserReturn);
                    }
                    else if (_statusConnect == "Error")
                    {
                        await SendMessageAsync(_messTel, Option.ErrorServer);
                    }
                }
                else
                {
                    _messTel = new MessageTelegram
                    {
                        IdChat = _update.Message.Chat.Id,
                        FirstName = _update.Message.Chat.FirstName,
                    };
                    await SendMessageAsync(_messTel, Option.ErrorText);
                }
            }
        }
        #region User
        public static async Task<string> ControlUser(MessageTelegram _messange)
        {
            IUser _testUser = new User
            {
                UserName = _messange.FirstName,
                Email = $"{_messange.IdChat}"
            };
            try
            {
                _userGet = _userLogic.Get(_defUser);
                for (int i = 0; i < _userGet.Count; i++)
                {
                    if ((_userGet[i].UserName == _testUser.UserName) && (_userGet[i].Email == _testUser.Email))
                    {
                        return "Old";
                    }
                }
                await AddUser(_testUser);
                return "New";
            }
            catch (Exception)
            {
                return "Error";
            }
            
        }
        private static async Task AddUser(IUser _user)
        {
            int _lastId = 0;
            for (int i = 0; i < _userGet.Count; i++)
            {
                int _tempId = int.Parse(_userGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            _user.Id = $"{_lastId}";
            _user.PasswordHash = "0000";
            _user.Role = "user";
            await _userLogic.AddAsync((User)_user, _defUser);
        }
        #endregion
        #region Bot
        private static async Task SendMessageAsync(MessageTelegram _messTel, string _textMess)
        {
            await _currentBotClient.SendTextMessageAsync(_messTel.IdChat, _textMess);
        }
        #endregion
        #region Chat
        public static async Task EventMessange(Messange _event)
        {
            MessageTelegram _model = new MessageTelegram
            {
                IdChat = long.Parse(_event.UserRecipientMess),
                TextMessange = $"Оператор ({_event.EmailSender}):  {_event.LastTextMessange}"
            };

            if (_event!=null)
            {
                _messangeGet = _messangeLogic.Get(_defUser);

                await SendMessageAsync(_model, _model.TextMessange);
            }
            
        }

        public static void SaveMessange(MessageTelegram _model)
        {
            Messange _controlItem = null;

            _userGet = _userLogic.Get(_defUser);
            User _conkretUser = _userGet.First(item => item.UserName == _model.FirstName);

            _messangeGet = _messangeLogic.Get(_defUser);
            try
            {
                _controlItem = _messangeGet.First(item => item.EmailSender == $"{_model.IdChat}" || item.UserRecipientMess == $"{_model.IdChat}");
            }
            catch (Exception)
            {
                _controlItem=new Messange();
            }
           
            DateTime _now = DateTime.Now;
            string _complexText = $"{_now}\n {_conkretUser.UserName} -> {_model.TextMessange}\n\n";
            Messange _newMessange = new Messange
            {
                Id = _controlItem.Id,
                TextMessange = _complexText,
                UserRecipientMess = Option.UserName,
                EmailSender = $"{_model.IdChat}",
                TimeRequest = $"{_now}"
            };

            if (_controlItem.Id == null)
            {
                AddMessange(_newMessange, _conkretUser);
            }
            else
            {
                EditMessange(_newMessange, _conkretUser);
            }
        }

        public static void AddMessange(Messange _messange, IUser _user)
        {
            _messangeGet = _messangeLogic.Get(_defUser);
            //id
            int _lastId = 0;
            for (int i = 0; i < _messangeGet.Count; i++)
            {
                int _tempId = int.Parse(_messangeGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            _messange.Id = $"{_lastId}";
            //
            _messangeLogic.Add(_messange, _user);
            _messangeGet.Add(_messange);
        }
        public static void EditMessange(Messange _messange, IUser _user)
        {
            _messangeGet = _messangeLogic.Get(_defUser);
            //UI
            for (int i = 0; i < _messangeGet.Count; i++)
            {
                if (_messangeGet[i].Id == _messange.Id)
                {
                    _messange.TextMessange += _messangeGet[i].TextMessange;
                    //
                    _messangeGet.Insert(i, _messange);
                    _messangeGet.RemoveAt(i + 1);
                }
            }
            _messangeLogic.Edit(_messange, _user);
        }
        #endregion
    }
}
