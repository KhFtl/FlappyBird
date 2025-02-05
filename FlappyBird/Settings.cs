using FlappyBird.Services.IServices;

namespace FlappyBird
{
    public static class Settings
    {
        public const string fileName = "RecordTable.txt";
        public const int TubeSpeed = 20;
        public static IRecordToFile GetCurrentServiceRecord()
        {
            return new WriteResult();
        }
    }
}
