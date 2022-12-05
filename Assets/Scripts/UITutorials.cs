using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{


    public class UITutorials : MonoBehaviour
    {
        [SerializeField] Text helpFulHints;
        [SerializeField] EnemyKillColor enemies;
        private int randomQuotes;
        private float countDownQuote = 10;
        private float countDownHold;
        private int quote1 = 1;
        private int quote2 = 2;
        private int quote3 = 3;
        private int quote4 = 4;
        private int quote5 = 5;
        private bool timeDone = true;
        private bool timeStart = true;
        
        

        void Start()
        {
            countDownHold = countDownQuote;
        }

        
        void Update()
        {
            
            randomQuotes = Random.Range(1, 5);

            if (randomQuotes == 1)
            {
                randomQuotes = quote1;
            }
            if (randomQuotes == 2)
            {
                randomQuotes = quote2;
            }
            if (randomQuotes == 3)
            {
                randomQuotes = quote3;
            }
            if (randomQuotes == 4)
            {
                randomQuotes = quote4;
            }
            if (randomQuotes == 5)
            {
                randomQuotes = quote5;
            }

            

            //  ///  ///  /// /// /// //

           

            if (timeStart == true)
            {
                QuoteStartCount();

                if (timeDone == true)
                {
                    if (randomQuotes == quote1)
                    {
                        helpFulHints.text = "Move Using W,A,S,D Keys".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote2)
                    {
                        helpFulHints.text = "Use Space to Jump".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote3)
                    {
                        helpFulHints.text = "You have to activate a blue ORB to make the enemies 'BLUE' ".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote4)
                    {
                        helpFulHints.text = "There is a 'Bonus Room' but you need 30 points to unlock it!".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote5)
                    {
                        helpFulHints.text = "Did you See the Boss yet? ;D".ToString();
                        timeDone = false;
                    }
                }
                
            }                                              
        }

        private void QuoteStartCount()
        {
            if (timeStart == true)
            {
                countDownQuote -= (1) * Time.fixedDeltaTime;
                QuoteCounter();
            }
        }
        private void QuoteCounter()
        {                    
            if (countDownQuote <= 0)
            {
                countDownQuote = countDownHold;
                if (enemies.closeToMe == false)
                {
                    timeDone = true;
                }
                else
                {
                    ButtonE();
                }
                
            }
        }
        private void ButtonE()
        {
            helpFulHints.text = "Press 'E' To Turn Enemies Blue".ToString();
        }
        private void ButtonT()
        {
            helpFulHints.text = "Press 'E' To Turn The Pillers Visible".ToString();
        }
        private void CountDownTime()
        {
            helpFulHints.text = "Time Limit: ".ToString();
        }
        private void CountDownWave()
        {
            helpFulHints.text = "Wave Round: ".ToString();
        }
    }
}
