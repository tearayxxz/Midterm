using System;
using System.Collections.Generic;
using System.Text;
enum Menu //สร้างหน้าเมนูโดยการกำหนดค่า
{
    PlayGame = 1,//กำหนดค่า
    Exit = 2//กำหนดค่า
}

namespace ConsoleApplication6
{
    class Program //class พื้นฐาน
    {
        static void Main(string[] args) //method พื้นฐาน
        {
            Menuscreen(); //เรียกMethod Menuscreen
            InputMenu(); //เรียกMethod InputMenu
            Game(); //เรียกMethod Game
        }
        static void Game() //สร้างmethod Game
        {
            HeadLine();//เรียกMethod HeadLine
            Random random = new Random((int)DateTime.Now.Ticks); //ใช้คำสั่งrandom

            string[] Space = { "Tennis", "Football", "Badminton" }; //ใส่คำที่จะrandom

            string Guessing = Space[random.Next(0, Space.Length)]; //ใช้คำสั่งrandom
            string ConvertToUppercase = Guessing.ToUpper();//แปลงเป็นตัวใหญ่เพื่อให้ง่ายจ่อการตรวจสอบ

            StringBuilder ShowingDisplay = new StringBuilder(Guessing.Length); //ประกาศClass StringBuilder
            for (int i = 0; i < Guessing.Length; i++) //สร้างลูปที่แสดงช่องว่างตามตัวอักษรจากข้อความ
            {
                ShowingDisplay.Append('_'); //แสดง"_"ตามตัวอักษรจากข้อความ
            }

            List<char> CheckCorrect = new List<char>(); //List ตัวอักษรที่ถูก
            List<char> CheckIncorrect = new List<char>(); //List ตัวอักษรที่ผิด

            int Incorrect = 0; //สร้างตัวแปรของจำนวนที่ผิดได้
            bool win = false; //สร้างตัวแปรของการชนะ
            int CharReavel = 0; //สร้างตัวแปรของตัวอักษรที่จะปรากฎ

            string input; //สร้างตัวแปรของinput
            char guess; //สร้างตัวแปรของตัวอักษรที่เเราจะทำการกรอกค่า

            while (!win && Incorrect != 7) //สร้างลูปกำหนดเงื่อนไข
            {
                Console.Write("Input letter alphabet: ");//แสดงข้อความ

                input = Console.ReadLine().ToUpper();//อ่านค่าที่เรากรอก
                guess = input[0];//รับค่า

                if (CheckCorrect.Contains(guess))//กำหนดเงื่อนไข ตรวจสอบคำที่ถูกและใช้ไปแล้ว
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);//แสดงข้อความโดยอ้างอิงจากguess
                    continue;//ถ้าเงื่อนไขเป็นจริงก็ดำเนินการทำคำสั่งในลูปต่อไป
                }
                else if (CheckIncorrect.Contains(guess))//กำหนดเงื่อนไข ตรวจสอบคำที่ผิดและใช้ไปแล้ว
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);//แสดงข้อความโดยอ้างอิงจากguess
                    continue;//ถ้าเงื่อนไขเป็นจริงก็ดำเนินการทำคำสั่งในลูปต่อไป
                }

                if (ConvertToUppercase.Contains(guess))//กำหนดเงื่อนไข
                {
                    CheckCorrect.Add(guess);//เพิ่มคำที่เรากรอกไปลงในListที่ถูก
                    Console.Clear();//เคลียร์หน้าจอ
                    Console.WriteLine("Play Game Hangman"); //แสดงข้อความ
                    Console.WriteLine("----------------------------------------");//แสดงข้อความ
                    Console.WriteLine("Incorrect Score: {0}", Incorrect);//แสดงข้อความโดยอ้างอิงจากIncorrect
                    for (int i = 0; i < Guessing.Length; i++) //สร้างลูป
                    {
                        if (ConvertToUppercase[i] == guess) //สร้างเงื่อนไขในขณะที่กำลังเล่น
                        {
                            ShowingDisplay[i] = Guessing[i]; //โชว์เมื่อกรอกถูก
                            CharReavel++; //เพิ่มค่าCharReavel
                        }
                    }

                    if (CharReavel == Guessing.Length) //กำหนดเงื่อนไขที่ทำให้ชนะ
                    {
                        win = true; //ชนะ
                    }
                }
                else //นอกเหนือจากที่เรากำหนด
                {
                    CheckIncorrect.Add(guess);//เพิ่มคำที่เรากรอกไปลงในListที่ผิด
                    Console.Clear();//เคลียร์หน้าจอ
                    Console.WriteLine("Play Game Hangman");//แสดงข้อความ
                    Console.WriteLine("----------------------------------------");//แสดงข้อความ
                    Console.WriteLine("Incorrect Score: {0}", Incorrect+1);//แสดงข้อความโดยอิงจาก Incorrect
                    Console.WriteLine("Nope, there's no '{0}' in it!", guess);//แสดงข้อความโดยอิงจาก guess
                    Incorrect++;//เพิ่มค่าที่กรอก
                }
                Console.WriteLine(ShowingDisplay.ToString());//แสดงข้อความของShowingDisplay.ToString()
            }
            result(win, Guessing); //เรียกmethod result เพื่อแสดงผลลัพธ์
        }
        static void Menuscreen() //สร้างMethod Menuscreen
        {
            Console.WriteLine("Welcome to Hangman Game");//แสดงข้อความ
            Console.WriteLine("---------------------------------");//แสดงข้อความ
            Console.WriteLine("1.Play game");//แสดงข้อความ
            Console.WriteLine("2.Exit");//แสดงข้อความ
        }
        static void InputMenu() //สร้างMethod InputMenu
        {
            Console.Write("Please Select Menu: ");//แสดงข้อความ
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));//อ่านค่าที่เรากรอก
            Console.Clear();//เคลียร์หน้าจอ
            PresentMenu(menu);//เรียกmethod PresentMenu
        }
        static void PresentMenu(Menu menu) //สร้างMethod PresentMenu
        {
            if (menu == Menu.PlayGame) //กำหนดเงื่อนไข
            {
                Game(); //เรียกmethodGame
            }
            else if(menu == Menu.Exit) //กำหนดเงื่อนไข
            {
                Exit(); //เรียกmethodExit
            }
        }
        public static void HeadLine() //สร้างMethod HeadLine
        {
            Console.WriteLine("Play Game Hangman");//แสดงข้อความ
            Console.WriteLine("----------------------------------------");//แสดงข้อความ
            Console.WriteLine("Incorrect Score: 0");//แสดงข้อความ
        }
        static void result(bool won, string wordToGuess) //สร้างMethod result
        {
            if (won)//กำหนดเงื่อนไข
            {
                Console.WriteLine("\n");//เว้นบรรทัด
                Console.WriteLine("----------------------------------------");//แสดงข้อความ
                Console.WriteLine("                You win!!               ");//แสดงข้อความ
                Console.WriteLine("----------------------------------------");//แสดงข้อความ
                Console.WriteLine("\n");//เว้นบรรทัด
            }
            else //นอกเหนือเงื่อนไข
            {
                Console.WriteLine("\n");//เว้นบรรทัด
                Console.WriteLine("----------------------------------------");//แสดงข้อความ
                Console.WriteLine("                Game Over               ");//แสดงข้อความ
                Console.WriteLine("----------------------------------------");//แสดงข้อความ
                Console.WriteLine("\n");//เว้นบรรทัด
            }

            Console.Write("Press ENTER to exit...");//แสดงข้อความ
            Environment.Exit(0); //จบการทำงาน
        }
        static void Exit()//สร้างMethod Exit
        {
            Environment.Exit(0); //จบการทำงาน
        }
    }
}