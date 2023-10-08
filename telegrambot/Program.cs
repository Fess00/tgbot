using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var client = new TelegramBotClient("");
using var cts = new CancellationTokenSource();


client.StartReceiving(Update, Error, cancellationToken: cts.Token);
Console.ReadKey();
await Task.Delay(int.MaxValue);
cts.Cancel();

static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
{
    throw new NotImplementedException();
}

async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
{
    Message? message = update.Message;
    if (message!.Text != null)
    {
        switch (message!.Text.ToLower())
        {
            case "/start":
                await client.SendTextMessageAsync(message.Chat.Id, "Привет, это бот пока еще без предназначения. Так что можешь включать режим ждуна :)", replyMarkup: new ReplyKeyboardRemove());
                break;
            case "/help":
                await client.SendTextMessageAsync(message.Chat.Id, "Пока боту нечего сказать вам :(", replyMarkup: new ReplyKeyboardRemove());
                break;
        }
    }
}
