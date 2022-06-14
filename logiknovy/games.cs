using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logiknovy
{
    public class games
    {
        public pin[] Pattern { get; set; }
        public List<attempt> Attempts { get; set; }
        public attempt ActualAttempt { get; set; }
        public GameState State { get; internal set; }

        public games()
        {
            Pattern = new pin[4];
            CreatePattern();
            Attempts = new List<attempt>();
            ActualAttempt = new attempt();
        }
        private void CreatePattern()
        {
            Random random = new Random();
            int rndValue;
            for(int i = 0; i < 4; i++)
            {
                rndValue = random.Next(1, 7);
                if(rndValue == 1)
                {
                    Pattern[i] = new pin() { Color = PinColor.Color1 };
                }
                else if (rndValue == 2)
                {
                    Pattern[i] = new pin() { Color = PinColor.Color2 };
                }
                else if (rndValue == 3)
                {
                    Pattern[i] = new pin() { Color = PinColor.Color3 };
                }

            }
        }
        public void EvaluateActualAttempt()
        {
            if(State == GameState.Run)
            {
                var ActualEvaluate = ActualAttempt.Evaluate(Pattern);
                if (ActualEvaluate.FindAll(value => value == true).Count == 4)
                {
                    State = GameState.Win;
                }
                Attempts.Add(ActualAttempt);
                if (Attempts.Count >= 10)
                {
                    State = GameState.Loss;
                }
                ActualAttempt = new attempt();
            }
        }
    }
    public enum GameState
    {
        Win,
        Loss,
        Run
    } 
}
