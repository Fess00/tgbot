using Telegram.Bot;
using Telegram.Bot.Types;

var client = new TelegramBotClient("840186999:AAGd3snwB0ONRTxrDYSEIX0fa_rKrQ2Tu60");
client.StartReceiving(Update, Error);

Console.ReadKey();

static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
{
    throw new NotImplementedException();
}

async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
{
    var message = update.Message;
    if (message.Text != null)
    {
        if (message.Text.ToLower() == "леонид")
        {
            await client.SendTextMessageAsync(message.Chat.Id, "Чиста гномик такой смищной, вобще ни магу");
            return;
        }
    }
}
