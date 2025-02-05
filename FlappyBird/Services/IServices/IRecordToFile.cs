using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Services.IServices
{
    public interface IRecordToFile
    {
        void WriteRecord(UserInfo userInfo, int score);
        List<UserInfo> ReadRecord(string fileName);
    }
}
