namespace VkSpammer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;

    using VKontakteNet;

    class Program
    {
        private const int olegBevzId = 3767334;

        [STAThread]
        static void Main(string[] args)
        {
            var connection = new Connection
            {
                ApplicationId = 2745992,
                Scope = (int)ScopeList.AccessToMessages
            };

            var dialog = new SigningWindow(connection);

            if (dialog.ShowDialog() == true)
            {
                var adapter = new WallAdapter(connection);

                var messageAdapter = new MessageAdapter(connection);

                DeleteMessages(messageAdapter);

                Spam(
                    100, 
                    i =>
                    {
                            var message = "Hello" +(i % 2 == 0 ? "!" : "!!");

                        var responce = messageAdapter.SendMessage(3767334, message);

                        if (responce.Success)
                        {
                            Console.WriteLine(string.Format("Message #{0} with text '{1}' was sended."), i, message);
                        }

                        return responce;
                    },
                    TimeSpan.FromSeconds(10));

                //var response = adapter.Post(171584020, "Привет", new[] { "Hello" });

                //var message = "Заплетенные в косичку волосы – отличная прическа на все случаи жизни.Косички – очень модная тенденция сегодня, их можно носить на работу или учебу, выходя в свет или отправляясь в путешествие.Приглашаю всех в свою группу, где вы найдете много всего интересного";

                //int posts = 0;

                //foreach (var receiver in receivers)
                //{
                //    var result = adapter.Post(receiver, message, new[] { "photo137457222_281801028", "http://vk.com/club37310676" });

                //    if (result)
                //    {
                //        posts++;
                //    }

                //    Thread.Sleep(TimeSpan.FromSeconds(10));
                //}
            }
        }

        private static void Spam(int actionCount, Func<int, Response> action, TimeSpan maxPeriod)
        {
            var random = new Random();

            for (var i = 0; i < actionCount; i++)
            {
                var responce = action(i);

                if (!responce.Success)
                {
                    Console.WriteLine(
                        string.Format(
                        "Error occured. Code : {0}. Message : {1}. Continue (y/n)?",
                        responce.Error.Code,
                        responce.Error.Message));

                    var character = ' ';

                    while (character != 'y' && character != 'n')
                    {
                        character = Convert.ToChar(Console.Read());
                    }

                    if (character == 'n')
                    {
                        break;
                    }
                }

                var waitingMilliseconds = random.NextDouble() * maxPeriod.Milliseconds;

                Console.WriteLine(string.Format("Waiting {0} milliseconds.", waitingMilliseconds));

                Thread.Sleep(TimeSpan.FromMilliseconds(waitingMilliseconds));
            }
        }

        private static void DeleteMessages(MessageAdapter messageAdapter)
        {
            var messageResponce = messageAdapter.GetHistory(3767334);

            var sended = messageResponce.Result.Where(message => message.Body != null && message.Body.Contains("Hello"));

            foreach (var message in sended)
            {
                var result = messageAdapter.DeleteMessage(message.Id);
            }
        }

        private static int[] SearchRecivers(Connection connection)
        {
            var profileAdapter = new ProfileAdapter(connection);

            // Находим друзей
            var friends = profileAdapter.GetFriends<UserExtended>();

            // Находим друзей друзей
            var friendsOfFriends = new List<UserExtended>();

            foreach (var userExtended in friends)
            {
                friendsOfFriends.AddRange(profileAdapter.GetFriends<UserExtended>(userExtended.Id).ToList());

                Console.WriteLine(friendsOfFriends.Count);
            }

            // Складываем всех друзей
            friendsOfFriends.AddRange(friends.ToList());

            var groupAdapter = new GroupAdapter(connection);

            var groups = groupAdapter.GetGroups(connection.UserId);

            var adminGroup = groups.First();

            var members = groupAdapter.GetGroupMembers(adminGroup.Id);

            friendsOfFriends = friendsOfFriends.Where(person => !members.Contains(person.Id)).ToList();

            friendsOfFriends = friendsOfFriends.Where(person => person.Sex == "1").ToList();

            friendsOfFriends = friendsOfFriends.Where(person => person.City == 144).ToList();

            var ids = friendsOfFriends.Select(person => person.Id).ToArray();

            ids = ids.Distinct().ToArray();

            using (var writer = new StreamWriter("ids.txt"))
            {
                foreach (var id in ids)
                {
                    writer.WriteLine(id);
                }
            }

            return ids;
        }
    }
}
