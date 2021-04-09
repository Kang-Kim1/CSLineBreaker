using System;
using System.IO;

namespace KMlinebreaker
{
    class Program
    {
        // 각 행의 Maxium Length 
        static int LEN = 100;

        public static void Main()
        {
            Console.WriteLine("** 텍스트 나누기 V1.1.0 **");
            string line;
            string output = "";
            try
            {
                /* Input File 읽기 - 같은 경로에 위치한 input.txt */
                System.IO.StreamReader file = new System.IO.StreamReader(@".\input.txt");
                Console.WriteLine("텍스트 나누는 중...");
                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine("line : {0}", line);
                    if (line.Length < LEN)
                    {
                        output += line;
                    }
                    else
                    {
                        string[] splited = line.Split(' ');
                        int charCounter = 0;

                        for (int i = 0; i < splited.Length; i++)
                        {
                            string str = splited[i];
                            int strLen = str.Length + 1;
                            
                            /* Text 길이 총합이 LEN 이하일 경우 */
                            if (charCounter + strLen <= LEN)
                            {
                                output += i == 0 ? str : " " + str;
                                charCounter += strLen;
                            }
                            /* LEN을 초과할 경우 */
                            else
                            {
                                output += Environment.NewLine;
                                output += str;
                                charCounter = strLen;
                            }
                            //Console.WriteLine("output : ");
                            //Console.WriteLine(output);
                        }
                    }
                    output += Environment.NewLine;
                }
                file.Close();
                
            } catch(FileNotFoundException ex)
            {
                /* Input 파일이 위치하지 않았을 경우 */ 
                Console.WriteLine("파일을 찾을 수 없습니다. 동일한 폴더에 Input 파일(.txt)을 추가해주세요.");
            } 

            //Console.WriteLine("SPLITED : {0}", file);
            
            /* 출력 파일 생성 */
            string path = @".\output.txt";
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                    Console.WriteLine("Output 파일이 생성되엇습니다.");
                }
            }
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(output);
            }
        }

    }
}
