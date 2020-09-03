using System;

namespace IsIPv4Address
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter IP adress: ");
            string ip = Console.ReadLine();
            if(isIPv4Address(ip) == true)
            {
                Console.WriteLine("Entered IP is IPv4 Address!");
            }
            else
            {
                Console.WriteLine("Entered IP is NOT IPv4 Address!");
            }
            Console.ReadLine();

        }
        static bool isIPv4Address(string inputString)
        {
            bool isIP = true;
            int dotCount = 0;
            bool res;
            int a;

            for (int i = 0; i < inputString.Length; i++)
            {
                if(inputString[i] == '.' && i != 0)
                {
                    dotCount++;
                }
                if(i == 0 || (i != 0 && inputString[i - 1] == '.' ))
                {
                    string between = "";
                    for (int j = i; j < inputString.Length; j++)
                    {
                        if(inputString[j] == '.')
                        {
                            break;
                        }
                        between += inputString[j];
                    }
                    res = int.TryParse(between, out a);
                    if(res == false || a < 0 || a > 255 || (between.Length != 1 && between[0] == '0'))
                    {
                        isIP = false;
                        break;
                    }
                }
            }
            if(dotCount != 3)
            {
                isIP = false;
            }
            return isIP; 
        }
    }
}
