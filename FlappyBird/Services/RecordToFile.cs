using FlappyBird.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlappyBird.Services
{
    public class RecordToFile : IRecordToFile
    {
        public void WriteRecord(UserInfo userInfo, int score)
        {
            using (FileStream fs = new FileStream(Settings.fileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{userInfo.Name};{userInfo.Score};{userInfo.StartGame};{userInfo.EndGame}");
                }
            }
        }

        List<UserInfo> IRecordToFile.ReadRecord(string fileName)
        {
            List<UserInfo> usrInfos = new List<UserInfo>();
            string str = "";
            string[] strArr;
            using (FileStream fs = new FileStream(Settings.fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        str = sr.ReadLine();
                        if (str.Count() > 0)
                        {
                            strArr = str.Split(';');
                            usrInfos.Add(new UserInfo
                            {
                                Name = strArr[0],
                                Score = Convert.ToInt32(strArr[1]),
                                StartGame = Convert.ToDateTime(strArr[2]),
                                EndGame = Convert.ToDateTime(strArr[3])
                            });
                        }
                    }
                }
            }
            return usrInfos;
        }
    }
}
