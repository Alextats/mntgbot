using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace mntgbot
{
    class Program
    {
        static TelegramBotClient Bot;
        static void Main(string[] args)
        {


            Bot = new TelegramBotClient("1812431254:AAGWMCZmy6-SS5QKrpW-O98A7e7orKRXrBQ");
            Bot.OnMessage += BotOnMessageRecived;
            Bot.OnCallbackQuery += BotCallBack;
        
            var me = Bot.GetMeAsync().Result;

            Console.WriteLine(me.FirstName);
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void BotCallBack(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static async  void BotOnMessageRecived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var message = e.Message;

            if (message == null || message.Type != MessageType.Text)
                return;

            string name = $"{message.From.FirstName} {message.From.LastName}";

            Console.WriteLine($"{name} отправил сообщение {message.Text}" );

            switch (message.Text)
            {
                case "/start":
                    string text =
                        @"/start - запуск
/volume 
/euus";

                   await  Bot.SendTextMessageAsync(message.From.Id, text);
                    break;
                case "/volume":
                    Bot.SendTextMessageAsync(message.From.Id,"что-то");
                    break;
                case "/euus":
                    Bot.SendTextMessageAsync(message.From.Id, "тоже что-то");
                        break;
                
                default:
                    break;
            }
        }
    }
}
