using System;

namespace FlappyBird
{
    public class UserInfo
    {
        public string Name { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
        public DateTime StartGame { get; set; }
        public DateTime EndGame { get; set; }
    }
}
