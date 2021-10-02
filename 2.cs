using System;
using System.Collections.Generic;
using System.Text;
enum Menu //สร้างหน้าเมนูโดยการกำหนดค่า
{
    Login = 1,//กำหนดค่า
    Register = 2//กำหนดค่า
}
namespace _2
{
    class BookStore
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
            Menu menu = (Menu)int.Parse(Console.ReadLine());//รับค่าจากkeyboard
            PresentMenu(menu, ListUser, selectBook, decide, bookStore, BorrowingUser);//เรียกmethod PresentMenu
        }
        static void PresentMenu(Menu menu, Registor ListUser, string selectBook, string decide, BookStore bookStore, Data BorrowingUser) //สร้างmethod PresentMenu ใช้กำหนดเงื่อนไข
        {
            if (menu == Menu.Login)//กำหนดเงือนไข ถ้าเท่ากับMenu.Login
            {
                Loginn(ListUser, selectBook,  decide,  bookStore, BorrowingUser); //ไปที่method Login
            }
            else if (menu == Menu.Register)
            {
                Registoration(ListUser, selectBook, decide, bookStore, BorrowingUser);
            }
        }
        static void Registoration(Registor ListUser, string selectBook, string decide, BookStore bookStore, Data BorrowingUser)
        {
            Console.Clear();

            Console.WriteLine("Register new Person");
            Console.WriteLine("------------------");

            Console.Write("Input name: ");
            BorrowingUser.User = Console.ReadLine();

            Console.Write("Input Password: ");
            BorrowingUser.PassWord = Console.ReadLine();

            Console.Write("Input User Type 1 = Student, 2 = Employee: ");
            BorrowingUser.Type = Console.ReadLine();

            if (BorrowingUser.Type == "1")
            {
                Console.WriteLine("Student ID: 62130701103");
            }
            else if (BorrowingUser.Type == "2")
            {
                Console.WriteLine("Employee ID: 5214785");
            }
            ListUser.addList(BorrowingUser);
            Console.WriteLine("Done");
            
            Console.Clear();
            Menuscreen();
            InputMenu(ListUser, selectBook, decide, bookStore, BorrowingUser);
        }
        static void Loginn(Registor ListUser, string selectBook, string decide, BookStore bookStore, Data BorrowingUser)
        {
            Console.Clear();
            Console.WriteLine("Login Screen");
            Console.WriteLine("------------------");
                Console.Write("Input name: ");
            string LoginUser = Console.ReadLine();
            Console.Write("Input Password: ");
            string LoginPass = Console.ReadLine();
            if (LoginUser == BorrowingUser.User)
            {
                if (LoginPass == BorrowingUser.PassWord)
                {
                    ListUser.getList();
                    Console.WriteLine("------------------");
                    Book(selectBook, decide, bookStore);
                }
            }
            else
            {
                Console.WriteLine("------------------");
                Console.WriteLine("  Worng!!!");
                Console.WriteLine("------------------");
                Console.WriteLine("Please Enter to continue");
                Console.ReadLine();
                Console.Clear();
                Menuscreen();
                InputMenu( ListUser, selectBook, decide, bookStore, BorrowingUser);
            }
        }
        static void Book(string selectBook, string decide, BookStore bookStore)
        {
            do
            {
                Console.WriteLine("Book List");
                Console.WriteLine("------------");
                foreach (string i in bookStore.BorrowList)
                {
                    Console.WriteLine("Book ID: {0}", (bookStore.BorrowList.IndexOf(i) + 1) + " ");
                    Console.Write("Book name: ");
                    Console.WriteLine(i);
                }
                Console.Write("Input book ID : ");
                selectBook = Console.ReadLine();
                switch (selectBook)
                {
                    case "1":
                        bookStore.addBorrowingList(bookStore.BorrowList[0]);
                        Console.WriteLine("Added " + bookStore.BorrowList[0]);
                        break;
                    case "2":
                        bookStore.addBorrowingList(bookStore.BorrowList[1]);
                        Console.WriteLine("Added " + bookStore.BorrowList[1]);
                        break;
                    case "3":
                        bookStore.addBorrowingList(bookStore.BorrowList[2]);
                        Console.WriteLine("Added " + bookStore.BorrowList[2]);
                        break;
                    case "4":
                        bookStore.addBorrowingList(bookStore.BorrowList[3]);
                        Console.WriteLine("Added " + bookStore.BorrowList[3]);
                        break;
                    default:
                        Console.WriteLine("Not Added to cart. found select number of flower");
                        break;
                }
                Console.WriteLine("You can stop this progress ? exit for >> exit << progress and pressany key for continue");
                decide = Console.ReadLine();
                Console.Clear();
            }
            while (decide != "exit");
            bookStore.BorrowResult();
        }
    }
}
