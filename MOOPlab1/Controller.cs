using System;
using System.Collections.Generic;
using System.Text;

namespace MOOPlab1
{
    class Controller
    {
        static View view = new View();
        static int left = 0;
        static int right = 100;

        public void Processing()
        {
            var randomizer = new Random();
            int randomAnswer = randomizer.Next(left, right);

            var guessing = new Model
            {
                LBound = left,
                RBound = right,
                Answer = randomAnswer,
                History = new List<Model>()
            };
            Game(guessing);

        }
        private void Game(Model guessing)
        {
            view.printMessage(View.Border + " " + guessing.LBound + " and " + guessing.RBound);

            guessing.YourNum = NumberInput(guessing);

            guessing.History.Add(new Model
            {
                Answer = guessing.Answer,
                LBound = guessing.LBound,
                RBound = guessing.RBound,
                YourNum = guessing.YourNum
            });

            if (guessing.YourNum > guessing.Answer)
            {
                view.printMessage("Answer is less than your number");
                guessing.RBound = guessing.YourNum - 1;
                Game(guessing);
            }
            else if (guessing.YourNum < guessing.Answer)
            {
                view.printMessage("Answer is bigger than your number");
                guessing.LBound = guessing.YourNum + 1;
                Game(guessing);
            }
            else if (guessing.YourNum == guessing.Answer)
            {
                view.printHistory(guessing);
                view.printMessage("You Win. Congratiulations!!!");
                return;
            }

        }
        private int ReadNumber()
        {
            int number = 0;

            try
            {
                number = Convert.ToInt32(view.read());
            }

            catch (Exception)
            {
                view.printMessage(View.Error);
                ReadNumber();
            }

            return number;
        }

        public int NumberInput(Model guessing)
        {
            bool correctInt = false;
            bool validInt = false;
            int num = -1;
            while (!correctInt || !(validInt))
            {
                correctInt = false;
                validInt = false;
                try
                {
                    num = Convert.ToInt32(view.read());
                    correctInt = true;
                    if (num >= guessing.LBound && num <= guessing.RBound) validInt = true;
                    else view.printMessage(View.Error + " " + View.Border + " " + guessing.LBound + " and " + guessing.RBound);
                }
                catch (Exception)
                {
                    view.printMessage(View.Error + " " + View.Border + " " + guessing.LBound + " and " + guessing.RBound);
                }

            }
            return num;
        }
    }
}
