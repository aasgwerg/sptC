using static TextRpg001.Program;
enum STARTSELECT    // 이름 하나하나 설정해주기   여러 선택지를 나타내는 상수의 집합
{
    SELECTSTATS,    // 다양한 선택지를 나타내는 상수
    SELECTMyInven,
    SELECTStore,
    NONESELECT     // 다른 선택지를 고를경우 나타낼 상수?
}

namespace TextRpg001
{
    internal class Program
    {
        // 처음화면에 소개말 선택지 띄우기 1. 스탯, 2. 템창, 3. 상점

        static STARTSELECT StartSelect()   // STARTSELECT위에서 정한 열거형이름 ,  StartSelect 이메서드의 이름
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.Write("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine();


            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점\n");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");


            ConsoleKeyInfo CKI = Console.ReadKey();
            Console.Clear();

            switch (CKI.Key)
            {
                case ConsoleKey.D1:
                    return STARTSELECT.SELECTSTATS;
                case ConsoleKey.D2:
                    return STARTSELECT.SELECTMyInven;
                case ConsoleKey.D3:
                    return STARTSELECT.SELECTStore;
                default:                                      // 모든 case문에 해당하지 않는 경우 실행되는 코드
                    Console.WriteLine("잘못된 입력입니다");   // 외의 선택을 하면 다시 처음으로
                    Console.ReadKey ();
                    return STARTSELECT.NONESELECT;
            }
        }



        public class Player     // 스텟등 바뀌는값이 필요
        {
            public int Level = 1;             
            public int Attack = 10;        // 좀더 구체적인 값이 나오고 커지면 float가 맞을듯 함
            public int Defense = 5;
            public int Health = 100;
            public int Gold = 1500;

            public List<Item> Inventory = new List<Item>();                           // 인벤토리 관리 정확하게 이해X 다시 복습하자
            public List<Item> EquippedItems = new List<Item>();                       // 장비의 장착, 해체 등 관리 마찬가지로 List부분 다시 공부하기

        }

        public class Item  // 다양한 아이템을 묶는 클래스
        {
            public string Name; 
            public int AttackBonus;
            public int DefenseBonus;


            public Item(string name, int attackBonus, int defenseBonus, string explanation)            // 각각 이름 공격력 방어력  함수로 만들어줘서 아이템 만들기
            {
                Name = name;
                AttackBonus = attackBonus;
                DefenseBonus = defenseBonus;
                
            }
            Item NoviceArmor = new Item("수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다.");
            Item ironArmor = new Item("무쇠 갑옷", 0, 9 , "무쇠로 만들어져 튼튼한 갑옷입니다.");
            Item SpartaArmor = new Item("스파르타의 갑옷", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");      
            Item OldSword = new Item("낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검 입니다.");          
            Item bronzeAxe = new Item("청동 도끼", 5, 0, "어디선가 사용됐던거 같은 도끼입니다.");
            Item SpartaSpire = new Item("스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.");
            Item tear = new Item("뉴비 개발자의 눈물", 0, 1, "어째서.. 눈물이?");
        }

        public class StoreItem       // 상점 아이템
        {
            public Item Item;
            public int Price;
            public bool Purchased;         // 아이템이 판매되었는지 아닌지 구분

            public StoreItem(Item item, int price)
            {
                Item = item;
                Price = price;
                Purchased = false;
            }
        }





        static void Stats()         
        {

            Player player = new Player();
            while(true)    // 나간다를 고르기 전까진 이안에서 못나가게 무한으로 돌린다
            {    
                
                Console.Clear();                                 // 0으로 나가기를 해도 로그가 남는다 왜지?
                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보가 표기됩니다\n");
                Console.WriteLine($"Lv. {player.Level}");
                Console.WriteLine("Chad (전사)");
                Console.WriteLine($"공격력: {player.Attack}");
                Console.WriteLine($"방어력: {player.Defense}");
                Console.WriteLine($"체력: {player.Health}");
                Console.WriteLine($"Gold: {player.Gold} G\n");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.WriteLine(">>");



                // ConsoleKey CK = Console.ReadyKey().Key; 로 받고 switch(CK)로 해도 무방하다
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D0:               // 0번을 누르면 함수를 파괴한다 즉 나간다
                        return;
                }
            }       
        }

        static void MyInven()
        {
          
            while (true)
            {
                Console.Clear();

                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                // 이부분은 무엇으로 채워야할까?

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.WriteLine(">>");
                Console.ReadKey();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D0:
                        return;

                }
            }
        }

        static void Store()
        {
            Player player = new Player();
            while (true)
            {

                List<StoreItem> storeItems = new List<StoreItem>()               // 리스트는 좀더 공부하고 다시 이해가필요
            {
                new StoreItem(new Item("수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다."), 1000),         // 내가만들어둔 아이템들을 클래스에서 가져온것 item , price
                new StoreItem(new Item("무쇠 갑옷", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다."), 2000),
                new StoreItem(new Item("스파르타의 갑옷", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."), 3500),
                new StoreItem(new Item("낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검 입니다."), 600),
                new StoreItem(new Item("청동 도끼", 5, 0, "어디선가 사용됐던거 같은 도끼입니다."), 1500),
                new StoreItem(new Item("스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다."), 2000)
            };

                Console.Clear();

                Console.WriteLine("상점(공사중)");                                 
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine($"Gold: {player.Gold} G\n");
                Console.WriteLine("[아이템 목록]");  
                           
                
                // 고민중


                Console.WriteLine("SOLD OUT\n");
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.WriteLine(">>");
                Console.ReadKey();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D0:
                        return;
                }


            }      
        }

        static void Main(string[] args)
        {

           while(true)
            {
                STARTSELECT SelectCheck = StartSelect();  //스타트셀렉트라는 enmu 을 리턴함  enum 변수이름 = 메서드호출

                switch (SelectCheck)
                {
                    case STARTSELECT.SELECTSTATS:
                        Stats();
                        break;
                    case STARTSELECT.SELECTMyInven:
                        MyInven();
                        break;
                    case STARTSELECT.SELECTStore:
                        Store();
                        break;
                }

            }


        }
    }
}