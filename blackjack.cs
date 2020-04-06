using System;

namespace blackjack
{
    class MainClass
    {　　　　　　　　
        //figuares that are used through whole program
        static int user, computer, money, deposit, ac, au;
        // user = the sum of user hands
        // computer = the sum of computer hands
        // money = user's moeny
        // deposit = user's bet

        public static void Main(string[] args)
        {

            //I need to add the explanation of the game


            //initial setting
            money = 100;

            Console.WriteLine("your money is now" + money);

            //repeat untill user lost all of money
            while (money > 0)
            {
                //reset of both sums
                user = 0;
                computer = 0;
                ac = 0;
                au = 0;
                //set deposit
                while (true)
                {
                    Console.Write("Type deposite：");
                    deposit = Convert.ToInt16(Console.ReadLine());
                    if (money > deposit)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("money is insufficient");
                    }
                }

                //open the computers first hand
                Cdraw();

                //disribution of two cards
                int card = Hand();
                Console.WriteLine("You drew " + card);
                user += card;
                if (card==11)
                {
                    ac++;
                }
                Udraw();

                //drawing based on dicision of user
                //user continues till his hand beyonds 21 or decids to "break"
                while (user < 21)
                {
                    string dicision = Udicision();
                    if (dicision.ToUpper() == "HIT")
                    {
                        Udraw();
                    }
                    //double deposit and draw only 1 card
                    else if (dicision.ToUpper() == "DOUBLEDOWN")
                    {
                        if (money >= 2 * deposit)
                        {
                            Udraw();
                            deposit *= 2;
                            break;
                        }
                        else 
                        {
                            Console.WriteLine("money is insufficient");
                        }
                    }
                    else // stand
                    {
                        break;
                    }
                }

                //drawing of computer
                if (user > 21)
                {
                    lose();
                }
                else
                {
                    //continue drawing till sum >= 16 

                    while (computer < 17)
                    {
                        Cdraw();
                    }
                    if (computer > 21 || user > computer)
                    {
                        win();
                    }
                    else
                    {
                        lose();
                    }

                }
                //current money
                Console.WriteLine("now your money is: " + money);
            }
            Console.ReadLine();
        }





        //to return hit or stand or doubledown
        private static string Udicision()　　
        {
            string dicision;
            while (true)
            {
                Console.WriteLine("Hit or Stand or DoubleDown?");
                dicision = Console.ReadLine();
                if (dicision.ToUpper() == "HIT" || dicision.ToUpper() == "STAND" || dicision.ToUpper() == "DOUBLEDOWN")
                {break;}
            }
            return dicision;
        }

        //to create random number
        static Random rnd = new Random();
        private static int Random()
        { 
            int random = rnd.Next(2, 14);
            return random;
        }

        //to adjust random number according to the rule
         private static int Hand()
        {
            int card = Random();

            if (card >= 12)
            {
                card = 10;
                return card;
            }
            else
            {
                return card;
            }

           
        }

        //the operation when user draw a card
        private static void Udraw()
        {
            int card = Hand();
            if (card == 11 && au == 0)
            {
                au++;
            }
            else if (card == 11 && au >= 1)
            {
                card = 1;
            }
            user += card;
            if (user >= 22 && au ==1)
            {
                user-=10;
                au++;
            }
            Console.WriteLine("You drew " + card);
            Console.WriteLine("your sum is " + user);
            if (au == 1)
            {
                Console.Write("'A'is counted as 11");
            }
            Console.WriteLine();
        }

        //the operation when computer dwar a card
        private static void Cdraw()
        {
            int card = Hand();
            if (card == 11 && ac == 0)
            {
                ac++;
            }
            else if (card == 11 && ac >= 1)
            {
                card = 1;
            }
            computer += card;
            if (computer >= 22 && ac == 1)
            {
                computer -= 10;
                ac++;
            }
            Console.WriteLine("Computer drew " + card);
            Console.WriteLine("computer's sum is " + computer);
            if (ac == 1)
            {
                Console.Write("'A'is counted as 11");
            }
            Console.WriteLine();
        }

        //operation when user lose
       private static void lose()
        {
            Console.WriteLine("YOU LOSE");
            money -= deposit;
        }

        //operation when computer lose
        private static void win()
        {
            Console.WriteLine("YOU WIN");
            money += deposit;
        }

    }

}

