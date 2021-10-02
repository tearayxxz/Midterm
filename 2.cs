using System;
using System.Collections.Generic;
using System.Text;
enum Menu
{
    Login = 1,
    Register = 2
}
namespace _2
{
    class BookStore
    {
        public List<string> BorrowList = new List<string>();
        List<string> Borrowing = new List<string>();
        public BookStore()
        {
            BorrowList.Add("NOW I UNDERSTAND");
            BorrowList.Add("REVOLUTIONARY WEALTH");
            BorrowList.Add("Six Degrees");
            BorrowList.Add("Les Vacances");
        }
        public void addToCart(string name)
        {
            Borrowing.Add(name);
        }

        public void BorrowResult()
        {
            if (Borrowing.Count == 0)
            {
                Console.WriteLine("No borrowing");
            }
            else
            {
                Console.WriteLine("Brrowing List:");
                foreach (string i in Borrowing)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
    class Data
    {
        public string User;
        public string PassWord;
        public string Type;
    }
    class Registor : Data
    {
        private List<Data> Account;
        public Registor()
        {
            Account = new List<Data>();
        }
        public void addList(Data account)
        {
            Account.Add(account);
        }
        public void getList()
        {
            foreach (Data account in Account)
            {
                if(account.Type == "1")
                {
                    Console.WriteLine("Student Management");
                    Console.WriteLine("------------------");
                    Console.WriteLine("Name:{0}", account.User);
                    Console.WriteLine("Student ID:62130701103", account.Type);
                }
                else if (account.Type == "2")
                {
                    Console.WriteLine("Employee Management");
                    Console.WriteLine("------------------");
                    Console.WriteLine("Name:{0}", account.User);
                    Console.WriteLine("Employee ID:5214785", account.Type);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string decide = "y";
            string selectBook = "";
            BookStore bookStore = new BookStore();
            Registor ListUser = new Registor();
            Menuscreen();
            InputMenu(ListUser, selectBook, decide, bookStore);
        }
        static void Menuscreen()
        {
            Console.WriteLine("Welcome to Digital Library");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");
        }
        static void InputMenu(Registor ListUser, string selectBook, string decide, BookStore bookStore)
        {
            Console.Write("Select Menu: ");
            Menu menu = (Menu)int.Parse(Console.ReadLine());
            PresentMenu(menu, ListUser, selectBook, decide, bookStore);
        }
        static void PresentMenu(Menu menu, Registor ListUser, string selectBook, string decide, BookStore bookStore)
        {
            if (menu == Menu.Login)
            {
                Loginn(ListUser, selectBook,  decide,  bookStore);
            }
            else if (menu == Menu.Register)
            {
                Registoration(ListUser, selectBook, decide, bookStore);
            }
        }
        static void Registoration(Registor ListUser, string selectBook, string decide, BookStore bookStore)
        {
            Console.Clear();
            Data B = new Data();

            Console.WriteLine("Register new Person");
            Console.WriteLine("------------------");

            Console.Write("Input name: ");
            B.User = Console.ReadLine();

            Console.Write("Input Password: ");
            B.PassWord = Console.ReadLine();

            Console.Write("Input User Type 1 = Student, 2 = Employee: ");
            B.Type = Console.ReadLine();

            if (B.Type == "1")
            {
                Console.WriteLine("Student ID: 62130701103");
            }
            else if (B.Type == "2")
            {
                Console.WriteLine("Employee ID: 5214785");
            }
            ListUser.addList(B);
            Console.WriteLine("Done");
            
            Console.Clear();
            Menuscreen();
            InputMenu(ListUser, selectBook, decide, bookStore);
        }
        static void Loginn(Registor ListUser, string selectBook, string decide, BookStore bookStore)
        {
            Console.Clear();
            Console.WriteLine("Login Screen");
            Console.WriteLine("------------------");
                Console.Write("Input name: ");
            string LoginUser = Console.ReadLine();
            Console.Write("Input Password: ");
            string LoginPass = Console.ReadLine();
            if (LoginUser == "kittinum")
            {
                if (LoginPass == "1234")
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
                Console.WriteLine("  Hint\n" +
                    "Name: kittinum\n" +
                    "Password: 1234");
                Console.WriteLine("------------------");
                Console.WriteLine("Please Enter to continue");
                Console.ReadLine();
                Console.Clear();
                Menuscreen();
                InputMenu( ListUser, selectBook, decide, bookStore);
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
                        bookStore.addToCart(bookStore.BorrowList[0]);
                        Console.WriteLine("Added " + bookStore.BorrowList[0]);
                        break;
                    case "2":
                        bookStore.addToCart(bookStore.BorrowList[1]);
                        Console.WriteLine("Added " + bookStore.BorrowList[1]);
                        break;
                    case "3":
                        bookStore.addToCart(bookStore.BorrowList[2]);
                        Console.WriteLine("Added " + bookStore.BorrowList[2]);
                        break;
                    case "4":
                        bookStore.addToCart(bookStore.BorrowList[3]);
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
