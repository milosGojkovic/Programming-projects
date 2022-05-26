using System;
using System.Threading;

namespace test
{
    
    }
class Program
{
    public static int pozicija = 24, _timer = 0, matHeight = 20, matWidth = 100;
    public static int[,,] matrica = new int[matWidth, matHeight, 3];
    public static bool kraj = false;
    public static string[] avionchar =
    {
        "   ^   ",
       @"  /A\  ",
       @" /KE$\ ",
        "  AAA  ",
        "  W W  "};
    public static int score = 0;
    public static int level = 1,tnivo=200;
    public static string igrac = "";
    
    public static void populate()
    {
        if (!kraj)
        {
            Console.WriteLine("Loading...");
            Thread.Sleep(100);
            Console.WriteLine("Window Height:{0}", Console.WindowHeight);
            Thread.Sleep(100);
            Console.WriteLine("Window Width:{0}", Console.WindowWidth);
            Thread.Sleep(100);
            Console.WriteLine("Checking Buffer");
            Console.WriteLine("Buffer Height:{0}", Console.BufferHeight);
            Thread.Sleep(100);
            Console.WriteLine("Buffer Width:{0}", Console.BufferWidth);
            Thread.Sleep(100);
            Console.WriteLine("Loading Highscores");
            Console.SetCursorPosition(10, 15);
            Console.WriteLine("Ime:");
            Console.SetCursorPosition(10, 16);
            igrac = Console.ReadLine();
            Console.Clear();
        }
        else kraj = false;
        Random r = new Random();
       
                for (int i = 0; i < matWidth; i++)
                for (int j = 0; j < matHeight; j++)
                {
                    if(j<5)matrica[i, j, 0] = r.Next(0, 3);
                    else matrica[i, j, 0] = 0;
                    Console.SetCursorPosition(15 + i, 3 + j);
                    switch (matrica[i, j, 0])
                    {
                        case 0: Console.Write(" "); break;
                        case 1: Console.Write("o"); break;
                        case 2: Console.Write("O"); break;
                    }
                }
        int w = Console.BufferWidth, h = Console.BufferHeight;
        for (int i = 0; i < w; i++)
        {
            Console.CursorLeft = i;
            Console.CursorTop = 0;
            Console.Write("#");
            Console.CursorLeft = i;
            h = h < 28 ? h : 28;
            Console.CursorTop = h;
            Console.Write("#");
        }
        for (int i = 0; i < h; i++)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = i;
            Console.Write("#");
            Console.CursorLeft = w - 1;
            Console.Write("#");
        }
    }
    public static void frame()
    {
        Console.CursorVisible = false;
        while(true)
        { 

        if ((_timer % tnivo) == 0)
        {
            Console.SetCursorPosition(1, 1);
            Console.Write("Igrac:{0}  ", igrac);
            Console.SetCursorPosition(1, 2);
            Console.Write("Poeni:{0}  ", score);
            Console.SetCursorPosition(1, 3);
            Console.Write("Nivo:{0}  ", level);
          
           
            

        }




        if (Console.KeyAvailable==true)
        {

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    if (pozicija > 12) pozicija--; break;
                case ConsoleKey.RightArrow:
                    if (pozicija <matWidth+11) pozicija++; break;
                case ConsoleKey.Spacebar:
                        {
                            matrica[pozicija-12, matHeight-1, 0] = -3;
                             break;
                        }
                case ConsoleKey.UpArrow:
                        {
                            matrica[pozicija - 12, matHeight-1, 0] = -1;
                            break;
                        }
                }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(pozicija, matHeight + 3);
            Console.Write(avionchar[0]);
            Console.SetCursorPosition(pozicija, matHeight + 4);
            Console.Write(avionchar[1]);
            Console.SetCursorPosition(pozicija, matHeight + 5);
            Console.Write(avionchar[2]);
            Console.SetCursorPosition(pozicija, matHeight + 6);
            Console.Write(avionchar[3]);
            Console.SetCursorPosition(pozicija, matHeight + 7);
            Console.Write(avionchar[4]);
            
            while (Console.KeyAvailable) { Console.ReadKey(true); }//Clearing keyboard buffer
            
        }
           if((_timer%2)==0)
            {
                tnivo = 200;
                if (score > 300) { level = 2; tnivo = 150; }
                if (score > 600) { level = 3; tnivo = 120; }
                if (score > 1000) { level = 4; tnivo = 100; }
                if (score > 2000) { level = 5; tnivo = 80; }
                if (score > 3000) { level = 6; tnivo = 500; }
                if (score > 5000) { level = 7; tnivo = 30; }
                if (score > 7000) { level = 8; tnivo = 20; }
                if (score > 10000) { level = 9; tnivo = 10; }
                if (score > 15000) { level = 10; tnivo = 8; }
                if (score > 20000) { level = 11; tnivo = 5; }
                for (int i = 0; i < matWidth; i++)
                    for (int j = 0; j < matHeight; j++)
                    {
                     
                      if(j<matHeight-1)
                        {
                            if (matrica[i, j + 1, 0] == -1)
                            {
                                matrica[i, j, 0]--;
                                matrica[i, j + 1, 0] = 0;
                                if (matrica[i, j, 0] >= 0)
                                {
                                    Console.SetCursorPosition(1, 2);
                                    Console.Write("Poeni:{0}  ", score);
                                    score++;
                                    Console.SetCursorPosition(1, 3);
                                    Console.Write("Nivo:{0}  ", level);
                                    }
                            }
                            if (matrica[i, j + 1, 0] == -3)
                            {
                                if (matrica[i, j, 0] > 0)
                                {
                                    score += matrica[i, j, 0];
                                    matrica[i, j, 0] = 0;
                                    matrica[i, j + 1, 0] = 0;
                                    Console.SetCursorPosition(1, 2);
                                    Console.Write("Poeni:{0}  ", score);
                                }
                                else
                                {

                                    matrica[i, j, 0] = -3;
                                    matrica[i, j + 1, 0] = 0;
                                }
                            }
                          
                          
                        }
                        Console.SetCursorPosition(15 + i, 3 + j);
                        switch (matrica[i, j, 0])
                        {
                            case -3: Console.ForegroundColor = ConsoleColor.Green;      Console.Write("@");break;
                            case -1: Console.ForegroundColor = ConsoleColor.Magenta;    Console.Write(".");break;
                            case 0:  Console.ForegroundColor = ConsoleColor.Red;        Console.Write(" ");break;
                            case 1:  Console.ForegroundColor = ConsoleColor.Yellow;     Console.Write("o");break;
                            case 2:  Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("O");break;
                        }
                    }
            }
            if (((_timer % tnivo) == 0)&& _timer >0)
            {
                
                for (int d = 0; d < matWidth; d++)
                    if (matrica[d, matHeight-1, 0] != 0)
                    {
                        for (int i = 0; i < matHeight; i++)
                            for (int j = 0; j < matWidth; j++)
                            {
                                Console.SetCursorPosition(15 + j, 3 + i);
                                Console.Write(" ");
                            }
                        Console.SetCursorPosition(15 +matWidth/2, 3 + matHeight/2);
                        Console.Write("Kraj igre! Stisni nesto da igras opet.");
                        kraj = true;
                        Thread.Sleep(1000);
                        Console.ReadKey();
                        Console.SetCursorPosition(15 + matWidth / 2, 3 + matHeight / 2);
                        Console.Write("                                      ");
                        populate();
                        _timer = 0;
                        score = 0;
                        level = 1;
                        break;
                    }
                if(!kraj)
                {
                    Random t = new Random();
                    for (int i = matHeight-1; i > 0; i--)
                        for (int j = 0; j < matWidth; j++)
                        {
                            matrica[j, i, 0] = matrica[j, i-1, 0];
                        }
                    for (int i = 0; i < matWidth; i++)
                        matrica[i, 0, 0] = t.Next(0, 3);
                }
                 

               
            }
            Thread.Sleep(1);
            _timer++;
            if (_timer == 30000)
                _timer = 0;
        }
}
        static void Main()
        {
            populate();
            Thread _graphics = new Thread(new ThreadStart(frame));
            _graphics.Start();
         
            
        }

    }



