using System;
using System.Collections.Generic;
enum Menu //สร้างหน้าเมนูโดยการกำหนดค่า
{
    Login = 1,//กำหนดค่า
    Register = 2//กำหนดค่า
}
namespace _2
{
    class BookStore //สร้างClass BookStore
    {
        public List<string> BorrowList = new List<string>(); //สร้างListของBorrowList
        List<string> Borrowing = new List<string>(); //สร้างListของBorrowing
        public BookStore() //ประกาศ class
        {
            BorrowList.Add("NOW I UNDERSTAND");//add List ชื่อหนังสื้อ
            BorrowList.Add("REVOLUTIONARY WEALTH");//add List ชื่อหนังสื้อ
            BorrowList.Add("Six Degrees");//add List ชื่อหนังสื้อ
            BorrowList.Add("Les Vacances");//add List ชื่อหนังสื้อ
        }
        public void addBorrowingList(string name) //ประกาศmethod addToCart ที่เอาไว้เก็บ list ของBorrowing
        {
            Borrowing.Add(name); //เก็บ list ของBorrowing
        }

        public void BorrowResult() //ประกาศmethod BorrowResult เอาไว้แสดงหนังสือที่ยืมไป
        {
            if (Borrowing.Count == 0)//กำหนดเงื่อนไข ถ้าตรงตามเงื่อนไข
            {
                Console.WriteLine("No borrowing");//แสดงข้อความ
            }
            else//นอกเหนือเงื่อนไข
            {
                Console.WriteLine("Brrowing List:");//แสดงข้อความ
                foreach (string i in Borrowing)//สร้างลูปที่แสดงหนังลือที่ยืมทั้งหมด
                {
                    Console.WriteLine(i);//แสดงข้อความลูปที่แสดงหนังลือที่ยืมทั้งหมด
                }
            }
        }
    }
    class Data //สร้างclassที่จะเป็นinheritance
    {
        public string User; //ประกาศตัวแปรชนิดstring
        public string PassWord; //ประกาศตัวแปรชนิดstring
        public string Type; //ประกาศตัวแปรชนิดstring
    }
    class Registor : Data //สร้างclassที่มีinheritance
    {
        private List<Data> Account; //สร้างlistของAccount
        public Registor() //ประกาศclass
        {
            Account = new List<Data>(); //กำหนดให้ Accountเก็บค่าที่Data
        }
        public void addList(Data account) //ประกาศmethod addList ที่เอาไว้เก็บ list ของAccount
        {
            Account.Add(account);//เก็บ list ของAccount
        }
        public void getList() //สร้างmethodที่เรียกlist ของAccountออกมาดูได้

        {
            foreach (Data account in Account) //สร้างลูปเพื่อพิมพ์
            {
                if(account.Type == "1") //กำหนดเงื่อนไข ถ้าaccount.Type == "1"
                {
                    Console.WriteLine("Student Management"); //แสดงข้อความ
                    Console.WriteLine("------------------"); //แสดงข้อความตกแต่ง
                    Console.WriteLine("Name:{0}", account.User); //แสดงข้อความโดยอิงค่าจาก account.User
                    Console.WriteLine("Student ID:62130701103", account.Type);//แสดงข้อความโดยอิงค่าจาก account.Type
                }
                else if (account.Type == "2") //กำหนดเงื่อนไข ถ้าaccount.Type == "2"
                {
                    Console.WriteLine("Employee Management");//แสดงข้อความ
                    Console.WriteLine("------------------");//แสดงข้อความตกแต่ง
                    Console.WriteLine("Name:{0}", account.User); //แสดงข้อความโดยอิงค่าจาก account.User
                    Console.WriteLine("Employee ID:5214785", account.Type);//แสดงข้อความโดยอิงค่าจาก account.Type
                }
            }
        }
    }
    class Program //class พื้นฐาน
    {
        static void Main(string[] args)//method พื้นฐาน
        {
            string decide = "y"; //ประกาศตัวแปรชนิดstring
            string selectBook = "";//ประกาศตัวแปรชนิดstring
            BookStore bookStore = new BookStore(); //ประกาศตัวแปรของClass
            Registor ListUser = new Registor();//ประกาศตัวแปรของClass
            Data BorrowingUser = new Data();//ประกาศตัวแปรของClass
            Menuscreen();//เรียกmethod Menuscreen
            InputMenu(ListUser, selectBook, decide, bookStore, BorrowingUser);//เรียกmethod InputMenu
        }
        static void Menuscreen()//สร้างmethod Menuscreen เมนูแรก
        {
            Console.WriteLine("Welcome to Digital Library"); //แสดงข้อความ
            Console.WriteLine("---------------------------"); //แสดงข้อความตกแต่ง
            Console.WriteLine("1.Login"); //แสดงข้อความเพื่อให้รู้ค่าที่เราจะกรอก
            Console.WriteLine("2.Register"); //แสดงข้อความเพื่อให้รู้ค่าที่เราจะกรอก
        }
        static void InputMenu(Registor ListUser, string selectBook, string decide, BookStore bookStore, Data BorrowingUser) //สร้างmethod InputMenu ใส่ค่าเมนูแรก
        {
            Console.Write("Select Menu: ");//แสดงข้อความ
            Menu menu = (Menu)int.Parse(Console.ReadLine());//กำหนดค่าให้รับค่าจากkerboard
            PresentMenu(menu, ListUser, selectBook, decide, bookStore, BorrowingUser);//เรียกmethod PresentMenu
        }
        static void PresentMenu(Menu menu, Registor ListUser, string selectBook, string decide, BookStore bookStore, Data BorrowingUser) //สร้างmethod PresentMenu ใช้กำหนดเงื่อนไข
        {
            if (menu == Menu.Login)//กำหนดเงือนไข ถ้าเท่ากับMenu.Login
            {
                Loginn(ListUser, selectBook,  decide,  bookStore, BorrowingUser); //ไปที่method Login
            }
            else if (menu == Menu.Register)//กำหนดเงือนไข Menu.Login
            {
                Registoration(ListUser, selectBook, decide, bookStore, BorrowingUser);//ไปที่method Registoration
            }
        }
        static void Registoration(Registor ListUser, string selectBook, string decide, BookStore bookStore, Data BorrowingUser)//สร้างmethod Registoration สำหรับการสมัคร
        {
            Console.Clear();//เคลียร์หน้าจอแสดงผล

            Console.WriteLine("Register new Person");//แสดงข้อความ
            Console.WriteLine("------------------");//แสดงข้อความตกแต่ง

            Console.Write("Input name: ");//แสดงข้อความ
            BorrowingUser.User = Console.ReadLine();//กำหนดค่าให้รับค่าจากkerboard

            Console.Write("Input Password: ");//แสดงข้อความ
            BorrowingUser.PassWord = Console.ReadLine();//กำหนดค่าให้รับค่าจากkerboard

            Console.Write("Input User Type 1 = Student, 2 = Employee: ");//แสดงข้อความ
            BorrowingUser.Type = Console.ReadLine();//กำหนดค่าให้รับค่าจากkerboard

            if (BorrowingUser.Type == "1")//กำหนาดเงื่อนไข ถ้า BorrowingUser.Type == "1"
            {
                Console.WriteLine("Student ID: 62130701103");// //แสดงข้อความ
            }
            else if (BorrowingUser.Type == "2")//กำหนาดเงื่อนไข ถ้า BorrowingUser.Type == "2"
            {
                Console.WriteLine("Employee ID: 5214785");////แสดงข้อความ
            }
            ListUser.addList(BorrowingUser); //เก็บค่าของBorrowingUser
            Console.WriteLine("Done"); //แสดงข้อความ

            Console.Clear();//เคลียร์หน้าจอแสดงผล
            Menuscreen();//เรียกmethod Menuscreen
            InputMenu(ListUser, selectBook, decide, bookStore, BorrowingUser);//เรียกmethod InputMenu
        }
        static void Loginn(Registor ListUser, string selectBook, string decide, BookStore bookStore, Data BorrowingUser)//สร้างmethod Loginn สำหรับการเข้าสู่ระบบ
        {
            Console.Clear();//เคลียร์หน้าจอแสดงผล
            Console.WriteLine("Login Screen");//แสดงข้อความ
            Console.WriteLine("------------------");//แสดงข้อความตกแต่ง
            Console.Write("Input name: ");//แสดงข้อความ
            string LoginUser = Console.ReadLine();//กำหนดค่าให้รับค่าจากkerboard
            Console.Write("Input Password: ");//แสดงข้อความ
            string LoginPass = Console.ReadLine();//กำหนดค่าให้รับค่าจากkerboard
            if (LoginUser == BorrowingUser.User)//กำหนดเงื่อนไข ถ้าLoginUser == BorrowingUser.User
            {
                if (LoginPass == BorrowingUser.PassWord)//กำหนดเงื่อนไข ถ้าLoginPass == BorrowingUser.PassWord
                {
                    ListUser.getList();//เรียกmethod getList()ของListUser
                    Console.WriteLine("------------------");//แสดงข้อความตกแต่ง
                    Book(selectBook, decide, bookStore);//เรียกmethod Book
                }
            }
            else//นอกเหนือเงื่อนไข
            {
                Console.WriteLine("------------------");//แสดงข้อความตกแต่ง
                Console.WriteLine("  Worng!!!"); //แสดงข้อความ
                Console.WriteLine("------------------");//แสดงข้อความตกแต่ง
                Console.WriteLine("Please Enter to continue");//แสดงข้อความ
                Console.ReadLine();//อ่านค่า
                Console.Clear();//เคลียร์หน้าจอแสดงผล
                Menuscreen();//เรียกmethod Menuscreen
                InputMenu( ListUser, selectBook, decide, bookStore, BorrowingUser);//เรียกmethod InputMenu
            }
        }
        static void Book(string selectBook, string decide, BookStore bookStore)//
        {
            do//ทำลูปกำหนดเงื่อนไขในขณะที่ decide ไม่เท่ากับ exit
            {
                Console.WriteLine("Book List");//แสดงข้อความ
                Console.WriteLine("------------");//แสดงข้อความตกแต่ง
                foreach (string i in bookStore.BorrowList)//ทำลูบของ bookStore.BorrowList
                {
                    Console.WriteLine("Book ID: {0}", (bookStore.BorrowList.IndexOf(i) + 1) + " ");//แสดงข้อความ
                    Console.Write("Book name: ");//แสดงข้อความ
                    Console.WriteLine(i);//แสดงข้อความ
                }
                Console.Write("Input book ID : ");//แสดงข้อความ
                selectBook = Console.ReadLine();//กำหนดค่าให้รับค่าจากkerboard
                switch (selectBook)//กำหนดเงื่อนไขของ selectBook
                {
                    case "1"://กำหนดเงือนไข
                        bookStore.addBorrowingList(bookStore.BorrowList[0]);//แอคค่าไปที่ addBorrowingList
                        Console.WriteLine("Added " + bookStore.BorrowList[0]);//แสดงข้อความที่เราแอดค่าไป
                        break;//หยุดการทำงาน
                    case "2"://กำหนดเงือนไข
                        bookStore.addBorrowingList(bookStore.BorrowList[1]);//แอคค่าไปที่ addBorrowingList
                        Console.WriteLine("Added " + bookStore.BorrowList[1]);//แสดงข้อความที่เราแอดค่าไป
                        break;//หยุดการทำงาน
                    case "3"://กำหนดเงือนไข
                        bookStore.addBorrowingList(bookStore.BorrowList[2]);//แอคค่าไปที่ addBorrowingList
                        Console.WriteLine("Added " + bookStore.BorrowList[2]);//แสดงข้อความที่เราแอดค่าไป
                        break;//หยุดการทำงาน
                    case "4"://กำหนดเงือนไข
                        bookStore.addBorrowingList(bookStore.BorrowList[3]);//แอคค่าไปที่ addBorrowingList
                        Console.WriteLine("Added " + bookStore.BorrowList[3]);//แสดงข้อความที่เราแอดค่าไป
                        break;//หยุดการทำงาน
                    default://นอกเหนือจากเงื่อนไขที่กำหนด
                        Console.WriteLine("Not Added to cart. found select number of flower");////แสดงข้อความ
                        break;//หยุดการทำงาน
                }
                Console.WriteLine("Type exit to end progress or press any key for continue");//แสดงข้อความ
                decide = Console.ReadLine();//กำหนดค่าให้รับค่าจากkerboard
                Console.Clear();//เคลียร์หน้าจอแสดงผล
            }
            while (decide != "exit");//ทำลูปกำหนดเงื่อนไขในขณะที่ decide ไม่เท่ากับ exit
            bookStore.BorrowResult();//เรียกmethod BorrowResultของ bookStore
        }
    }
}
