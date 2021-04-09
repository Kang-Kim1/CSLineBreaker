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
                // Read the file and display it line by line.  
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
                            ////Console.WriteLine("str : {0}", str);
                            // 한 줄 길이 120이 이하일 경우
                            string str = splited[i];
                            int strLen = str.Length + 1;
                            //Console.WriteLine("char count {0}", charCounter);

                            if (charCounter + strLen <= LEN)
                            {
                                output += i == 0 ? str : " " + str;
                                charCounter += strLen;
                            }
                            // 1줄 길이 120 초과하기 전
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
                    //Console.WriteLine("OUTPUT : {0}", output );
                    output += Environment.NewLine;
                }

                file.Close();
            } catch(FileNotFoundException ex)
            {
                Console.WriteLine("파일을 찾을 수 없습니다. 동일한 폴더에 Input 파일(.txt)을 추가해주세요.");
            } 

            //Console.WriteLine("SPLITED : {0}", file);

            // Suspend the screen.  
   //         System.Console.ReadLine();

            string path = @".\output.txt";
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                    //Console.WriteLine("File Created !");

                    // Create a file to write to.
                    
                }
            }
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(output);
            }
        }

    }
}
