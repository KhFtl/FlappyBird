using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Services.IServices
{
    public class WriteResult : IRecordToFile
    {
        public List<UserInfo> ReadRecord(string fileName)
        {
            fileName = "NewTable.txt";
            List<UserInfo> usrInfos = new List<UserInfo>();
            string str = "";
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    int i = 0;
                    string name = "";
                    int score = 0;
                    DateTime start=new DateTime();
                    DateTime end = new DateTime();
                    while (!sr.EndOfStream)
                    {
                        str = sr.ReadLine();
                        if (str.Count() > 0)
                        {
                            if (i == 0)
                            {
                                name = str;    
                            }
                            if (i == 1)
                            { 
                                score = Convert.ToInt32(str);
                            }
                            if (i == 2)
                            { 
                                start = Convert.ToDateTime(str);
                            }
                            if (i == 3)
                            { 
                                end = Convert.ToDateTime(str);
                                usrInfos.Add(new UserInfo 
                                                        {
                                                            Name = name,
                                                            Score = score,
                                                            StartGame = start,
                                                            EndGame = end
                                                        }
                                            );
                                i = -1;
                            }
                        }
                        i++;
                    }
                }
            }
            return usrInfos;
        }

        public void WriteRecord(UserInfo userInfo, int score)
        {
            using (FileStream fs = new FileStream("NewTable.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(userInfo.Name);
                    sw.WriteLine(userInfo.Score);
                    sw.WriteLine(userInfo.StartGame);
                    sw.WriteLine(userInfo.EndGame);
                }
            }
        }
    }
}
