using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan
{
    public static class Mood
    {
        public static string GetMood(int totalPoints)
        {
            string mood = string.Empty;
            if (totalPoints < -5)
            {
                mood = "Angry";
            }
            else if (totalPoints <= 0)
            {
                mood = "Sad";
            }
            else if (totalPoints <= 15)
            {
                mood = "Happy";
            }
            else
            {
                mood = "JavaScript";
            }

            return mood;
        }
    }
}
