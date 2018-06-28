using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class Program
    {
        public static void TxtRead(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read;");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        public static void TxtWrite(string fileName)
        {
            string[] names = new string[] { "Zara Ali", "Nuha Ali" };
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (string s in names)
                {
                    sw.WriteLine(s);
                }
            }

            //从文件读取并显示每行
            string line = "";
            using (StreamReader sr = new StreamReader(fileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.ReadKey();
        }

        public static void BinaryReadWrite()
        {
            BinaryWriter bw;
            BinaryReader br;
            int i = 25;
            double d = 3.14157;
            bool b = true;
            string s = "I am happy";

            //创建文件
            try
            {
                bw = new BinaryWriter(new FileStream("mydata", FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
                return;
            }

            //写入文件
            try
            {
                bw.Write(i);
                bw.Write(d);
                bw.Write(b);
                bw.Write(s);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot write to file.");
                return;
            }
            bw.Close();
            //读取文件
            try
            {
                br = new BinaryReader(new FileStream("mydata",FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }
            try
            {
                i = br.ReadInt32();
                Console.WriteLine("Integer data : {0}", i);
                d = br.ReadDouble();
                Console.WriteLine("Double data : {0}", d);
                b = br.ReadBoolean();
                Console.WriteLine("Boolean data : {0}", b);
                s = br.ReadString();
                Console.WriteLine("String data : {0}", s);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read file.");
                return;
            }
            br.Close();
            Console.ReadKey();
        }

        public static void GetDirectoryInfo(string dirPath)
        {
            //创建一个DirectoryInfo对象
            DirectoryInfo mydir = new DirectoryInfo(@dirPath);
            //获取目录中的文件以及它们的名称和大小
            FileInfo[] f = mydir.GetFiles();
            foreach (FileInfo file in f)
            {
                Console.WriteLine("File Name: {0} Size: {1}",file.Name,file.Length);
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            //FileStream fs = new FileStream("test.dat",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            //for (int i = 1; i <= 20; i++)
            //{
            //    fs.WriteByte((byte)i);
            //}

            //fs.Position = 0;

            //for (int i = 0; i <= 20; i++)
            //{
            //    Console.Write(fs.ReadByte() + "");
            //}
            //fs.Close();
            //Console.ReadKey();

            //TxtRead("Jamaica.txt");

            //TxtWrite("names.txt");

            //BinaryReadWrite();

            GetDirectoryInfo("C:/Windows");
        }
    }
}
