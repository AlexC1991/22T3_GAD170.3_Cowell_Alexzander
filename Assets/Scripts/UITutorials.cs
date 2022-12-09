
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{


    public class UITutorials : MonoBehaviour
    {
        [Header("Text")]
        [SerializeField] private Text helpFulHints; // Text for the randomly generated hints for the middle display.
        [SerializeField] private Text timeOrWave; // Text for the popUI text that comes up whenever you activate the timer or wave.
        [SerializeField] private Text textTutorial1; // Text for the first Tutorial screen.
        [SerializeField] private Text textTutorial2; // Text for the second Tutorial screen.
        [SerializeField] private Text textTutorial3; // Text for the third Tutorial screen.
        [SerializeField] private Text textTutorial4; // Text for the forth Tutorial screen.
        [SerializeField] private Text textroom2Tutorial; // // Text for room 2 tutorial screen.
        [SerializeField] private Text healthNumber; // Text for the Health displayed.

        [Header("'Other' Scripts")] // All the other scripts that need referencing for this one.
        [SerializeField] private EnemyKillColor enemies;
        [SerializeField] private InTangable inTang;
        [SerializeField] private InTangable inTang2;
        [SerializeField] private Room2 roomWall2;
        [SerializeField] private DoorControl doorController;
        

        [Header("Canvas GameObjects")]
        [SerializeField] private GameObject timeOrWaveUI; // Pop Up UI image for the display for the time or wave text.
        [SerializeField] private GameObject tutorial1; // UI Image for the first Tutorial screen.
        [SerializeField] private GameObject tutorial2; // UI Image for the second Tutorial screen.
        [SerializeField] private GameObject tutorial3; // UI Image for the third Tutorial screen.
        [SerializeField] private GameObject tutorial4; // UI Image for the forth Tutorial screen.
        [SerializeField] private GameObject room2Tutorial; // UI Image for room 2 Tutorial screen.


        private int randomQuotes; // Gets the int from the random range.
        private float countDownQuote = 10; // Count down start for the next quote.
        private float countDownHold; // Holds the value of the original Count Down number for when it gets to zero.
        private int quote1 = 1; // First quote hold number.
        private int quote2 = 2; // Second quote hold number.
        private int quote3 = 3; // Third quote hold number.
        private int quote4 = 4; // Forth quote hold number.
        private int quote5 = 5; // Fith quote hold number.
        private int quote6 = 6; // Sixth quote hold number.
        private bool timeDone = true; // Time is done bool.
        private bool timeStart = true; // Start time bool.
        private bool reCheck = true; // Rechecking if one function has started yet.
        private bool reCheckAgain = true; // Rechecking again if one function has started yet.
        private bool popUI = false; // Bool for the pop up UI if it should be displayed or not.
        [HideInInspector]
        public bool destroyGO = false; // destroyed UI for another script to function. Hidden so it cleans up the Inspector.
        private bool activate2; // Says if something has been activated or not.
        

        void Start()
        {
            activate2 = true; // Activator has started at start.
            countDownHold = countDownQuote; // count down hold will keep the count down quotes number for when the quote hits 0.
            popUI = false; // Pop up UI will always be false unless it is called like a timer.
            Time.timeScale = 0; // Game will start with the time scale to be frozen so the player can look at the tutorial before playing.
            Tutorial1Screen1(); // Starts the tutorial UI for the game.
            
            
        } // Everything that is supposed to start when the game loads will start here.

        
        void Update() 
        {

            if (roomWall2.room2Interact == true) 
            {
                Room2Tutorial();
            } // If you pass throught a intangable wall to room 2 you will get the tutorial for room 2 to start.

            //if (doorController.openDoor2 == true) // Newest part of the script however not needed for the game and has some issues currently.
            //{
            //    RoomCheck();
            //    SecondsTimer();
            //}

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (reCheck == true)
            {
                AlwaysCheck();
                
            }
            else
            {
                FirstCheck();
            }

            if (reCheckAgain == true)
            {
                FirstCheck();
            }
            else
            {
                SecondCheck();
            }          

            randomQuotes = Random.Range(1, 7);

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
            if (randomQuotes == 6)
            {
                randomQuotes = quote6;
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
                        helpFulHints.text = "Did you See the Boss yet? 😁".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote6)
                    {
                        helpFulHints.text = "Press 'ESC' at any point to exit the game".ToString();
                        timeDone = false;
                    }
                }
                
            }  if (popUI == true)
            {
                timeOrWaveUI.SetActive(true);
                timeOrWaveUI.GetComponent<CanvasGroup>().alpha = 1;
                timeOrWaveUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            if (inTang.timerSS == false)
            {
                popUI = false;

                if (popUI == false)
                {
                    timeOrWaveUI.SetActive(false);
                    timeOrWaveUI.GetComponent<CanvasGroup>().alpha = 0;
                    timeOrWaveUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
                
            }

            if (popUI == false)
            {
                timeOrWaveUI.SetActive(false);
                timeOrWaveUI.GetComponent<CanvasGroup>().alpha = 0;
                timeOrWaveUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        } // Everything that will need to be updated constantly will do so here.

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
                timeDone = true;
            }
            
        }

        private void FirstCheck()
        {
            if (inTang.playerIsClose == true)
            {
                ButtonT();
                timeStart = false;               
            }
            else if (inTang2.playerIsClose == true)
            {
                ButtonT();
                timeStart = false;                
            }
            else if (enemies.closeToMe == true)
            {
                ButtonE();
                timeStart = false;                
            }
            
            reCheckAgain = false;
           
        }

        private void SecondCheck()
        {
            if (inTang.playerIsClose == false)
            {
                timeStart = true;
                
            }
            else if (enemies.closeToMe == false)
            {
                timeStart = true;
                
            }
            else if (inTang.timerSS == false)
            {
                timeStart = true;
                
            }
            else if (inTang.timeWolf == false)
            {
                timeStart = true;
                
            }
            else if (inTang2.playerIsClose == false)
            {
                timeStart = true;
                
            }
            reCheck = true;
        }

        private void AlwaysCheck()
        {
             if (inTang.timeWolf == true){
                CountDownTime();
                timeStart = false;
                popUI = true;
             }
             else if (inTang.timerSS == true){
                CountDownTime();
                timeStart = false;
                popUI = true;
             }           
              reCheck = false;
              reCheckAgain = true;
        }

        private void RoomCheck()
        {
            if (doorController.openDoor2 == true)
            {
                if (activate2 == true)
                {
                    Room2NowOpen();
                    timeStart = false;
                }
                reCheck = false;
                reCheckAgain = true;
            }
        }
        private void ButtonE()
        {
            helpFulHints.text = "Press 'E' To Turn Enemies Blue for 15 Seconds".ToString();
        }
        private void ButtonT()
        {
            helpFulHints.text = "Press 'E' To Turn The Pillers Visible".ToString();
        }
        private void CountDownTime()
        {
            timeOrWave.text = "Time Limit: " + inTang.timer.ToString("F0");
        }
        private void CountDownWave()
        {
            helpFulHints.text = "Wave Round: ".ToString();
        }
        private void Room2NowOpen()
        {
            helpFulHints.text = "Room 2 is Opened".ToString();
        }

        private void SecondsTimer()
        {            
            float time = 0.5f;
            float originalTime = time;
            time -= (1) * Time.deltaTime;
            Debug.Log(time);

            if(time <= 0)
            {
                Debug.Log("Finished Timer"); 
                activate2 = false;
                timeStart = true;
                time = originalTime;
            }
        }

        public void Tutorial1Screen1()
        {
            
            textTutorial1.text = "Hello & Welcome to The Wonder Wall. \n " + "In this first room you will need to collect 5 coints to proceed".ToString();
            
            tutorial1.GetComponent<CanvasGroup>().alpha = 1;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = true;
            tutorial1.GetComponent<CanvasGroup>().interactable = true;

            tutorial2.GetComponent<CanvasGroup>().alpha = 0;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial2.GetComponent<CanvasGroup>().interactable = false;

            tutorial3.GetComponent<CanvasGroup>().alpha = 0;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial3.GetComponent<CanvasGroup>().interactable = false;

            tutorial4.GetComponent<CanvasGroup>().alpha = 0;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial4.GetComponent<CanvasGroup>().interactable = false;

        }
        public void Tutorial1Screen2()
        {
            textTutorial2.text = "On the bottom of your screen will be the UI read out \n " + "Left and right are what you make of it and the middle are suggestions or interactions".ToString();

            tutorial1.GetComponent<CanvasGroup>().alpha = 0;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial1.GetComponent<CanvasGroup>().interactable = false;

            tutorial2.GetComponent<CanvasGroup>().alpha = 1;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = true;
            tutorial2.GetComponent<CanvasGroup>().interactable = true;

            tutorial3.GetComponent<CanvasGroup>().alpha = 0;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial3.GetComponent<CanvasGroup>().interactable = false;

            tutorial4.GetComponent<CanvasGroup>().alpha = 0;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial4.GetComponent<CanvasGroup>().interactable = false;
        }
        public void Tutorial1Screen3()
        {
            textTutorial3.text = "In each room there will be different hazards like water or space of which will kill you instantly and another which just spawns enemies to try and kill you".ToString();
           
            tutorial1.GetComponent<CanvasGroup>().alpha = 0;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial1.GetComponent<CanvasGroup>().interactable = false;

            tutorial2.GetComponent<CanvasGroup>().alpha = 0;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial2.GetComponent<CanvasGroup>().interactable = false;

            tutorial3.GetComponent<CanvasGroup>().alpha = 1;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = true;
            tutorial3.GetComponent<CanvasGroup>().interactable = true;

            tutorial4.GetComponent<CanvasGroup>().alpha = 0;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial4.GetComponent<CanvasGroup>().interactable = false;
        }
        public void Tutorial1Screen4()
        {
            textTutorial4.text = "You can collect coins which will open doors and add points to your total score. \n " + "If you hit a blue orb with E you can turn enemies blue which than you can kill like Pac Man :D" .ToString();

            tutorial1.GetComponent<CanvasGroup>().alpha = 0;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial1.GetComponent<CanvasGroup>().interactable = false;

            tutorial2.GetComponent<CanvasGroup>().alpha = 0;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial2.GetComponent<CanvasGroup>().interactable = false;

            tutorial3.GetComponent<CanvasGroup>().alpha = 0;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial3.GetComponent<CanvasGroup>().interactable = false;

            tutorial4.GetComponent<CanvasGroup>().alpha = 1;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = true;
            tutorial4.GetComponent<CanvasGroup>().interactable = true;
        }

        public void EndOfTutorial()
        {
            tutorial1.GetComponent<CanvasGroup>().alpha = 0;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial1.GetComponent<CanvasGroup>().interactable = false;

            tutorial2.GetComponent<CanvasGroup>().alpha = 0;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial2.GetComponent<CanvasGroup>().interactable = false;

            tutorial3.GetComponent<CanvasGroup>().alpha = 0;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial3.GetComponent<CanvasGroup>().interactable = false;

            tutorial4.GetComponent<CanvasGroup>().alpha = 0;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial4.GetComponent<CanvasGroup>().interactable = false;

            Time.timeScale = 1;
        }

        private void Room2Tutorial()
        {
            
            room2Tutorial.GetComponent<CanvasGroup>().alpha = 1;
            room2Tutorial.GetComponent<CanvasGroup>().blocksRaycasts = true;
            room2Tutorial.GetComponent<CanvasGroup>().interactable = true;
            textroom2Tutorial.text = "You made it to room 2! :D. \n" + "In this room you will have to use the 2 purple buttons to activate the bridge. Once you have done so you have 35 seconds to get to the other block. Collect all coins to open the next room!".ToString();
            
        }

        public void Room2TutorialOver()
        {           
            room2Tutorial.SetActive(false);
            
            destroyGO = true;
        }


    }
}
