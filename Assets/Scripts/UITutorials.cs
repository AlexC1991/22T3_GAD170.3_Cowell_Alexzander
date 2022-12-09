
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

            if (Input.GetKeyDown(KeyCode.Escape)) // If you press the 'ESC' key will will quit the game.
            {
                Application.Quit();
            }

            if (reCheck == true) // if reCheck is true it will start the method below.
            {
                AlwaysCheck();
                
            }
            else // if not true it will start the first Check method.
            {
                FirstCheck(); 
            }

            if (reCheckAgain == true) // if reCheckAgain is true than will check First Check method.
            {
                FirstCheck();
            }
            else // if reCheckAgain is false than will start the second check method.
            {
                SecondCheck(); 
            }          

            randomQuotes = Random.Range(1, 7); // RandomQuotes will equal to a random number between 1 & 7.

            if (randomQuotes == 1) // If Random Quotes equal to 1 than it will equal a quote 1 int.
            {
                randomQuotes = quote1; 
            }
            if (randomQuotes == 2) // If Random Quotes equal to 2 than it will equal a quote 2 int.
            {
                randomQuotes = quote2;
            }
            if (randomQuotes == 3) // If Random Quotes equal to 3 than it will equal a quote 3 int.
            {
                randomQuotes = quote3;
            }
            if (randomQuotes == 4) // If Random Quotes equal to 4 than it will equal a quote 4 int.
            {
                randomQuotes = quote4;
            }
            if (randomQuotes == 5) // If Random Quotes equal to 5 than it will equal a quote 5 int.
            {
                randomQuotes = quote5;
            }
            if (randomQuotes == 6) // If Random Quotes equal to 6 than it will equal a quote 6 int.
            {
                randomQuotes = quote6;
            }

            // If it Equals 7 it will Equal to null.
            

            //  ///  ///  /// /// /// //

           

            if (timeStart == true) // if timeStar is true than quote start counter method will start.
            {
                QuoteStartCount();

                if (timeDone == true) // If timeDone is true than it will activate one of the random quotes below.
                {
                    if (randomQuotes == quote1) // If randomQuotes equals quote 1 than it will print off the following string and set timeDone to false.
                    {
                        helpFulHints.text = "Move Using W,A,S,D Keys".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote2) // If randomQuotes equals quote 2 than it will print off the following string and set timeDone to false.
                    {
                        helpFulHints.text = "Use Space to Jump".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote3) // If randomQuotes equals quote 3 than it will print off the following string and set timeDone to false.
                    {
                        helpFulHints.text = "You have to activate a blue ORB to make the enemies 'BLUE' ".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote4) // If randomQuotes equals quote 4 than it will print off the following string and set timeDone to false.
                    {
                        helpFulHints.text = "There is a 'Bonus Room' but you need 30 points to unlock it!".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote5) // If randomQuotes equals quote 5 than it will print off the following string and set timeDone to false.
                    {
                        helpFulHints.text = "Did you See the Boss yet? 😁".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote6) // If randomQuotes equals quote 6 than it will print off the following string and set timeDone to false.
                    {
                        helpFulHints.text = "Press 'ESC' at any point to exit the game".ToString();
                        timeDone = false;
                    }
                }
                
            }  if (popUI == true) // If popUI is true than will start the following code.
            {
                timeOrWaveUI.SetActive(true); // Will set the timeorWaveUI to be activated.
                timeOrWaveUI.GetComponent<CanvasGroup>().alpha = 1; // Will set the timeorWave UI to have a alpha equal to 1 in the canvas group.
                timeOrWaveUI.GetComponent<CanvasGroup>().blocksRaycasts = false; // Will set the timeorWave UI canvas group blockedraycast to be deactivated.
            }
            if (inTang.timerSS == false) // If the intangable script timer SS is set to false than popUI will be false as well.
            {
                popUI = false;

                if (popUI == false) // If the popUI is set to false than it will set the code below for the canvas.
                {
                    timeOrWaveUI.SetActive(false); // Will set the timeorWaveUI to be Deactivated.
                    timeOrWaveUI.GetComponent<CanvasGroup>().alpha = 0; // Will set the timeorWave UI to have a alpha equal to 0 in the canvas group.
                    timeOrWaveUI.GetComponent<CanvasGroup>().blocksRaycasts = true; // Will set the timeorWave UI canvas group blockedraycast to be activated.
                }
                
            }

            if (popUI == false) // If the popUI is set to false than it will set the code below for the canvas.
            {
                timeOrWaveUI.SetActive(false); // Will set the timeorWaveUI to be Deactivated.
                timeOrWaveUI.GetComponent<CanvasGroup>().alpha = 0; // Will set the timeorWave UI to have a alpha equal to 0 in the canvas group.
                timeOrWaveUI.GetComponent<CanvasGroup>().blocksRaycasts = true; // Will set the timeorWave UI canvas group blockedraycast to be activated.

                // This is done to keep bugs from allowing the popUI to turn off correctly.
            }
        } // Everything that will need to be updated constantly will do so here.

        private void QuoteStartCount() // Starts the Quote counter method.
        {
            if (timeStart == true) // If the Start timer is true than it will start the count down float using fixed time delta by -1 and start the quote counter method.
            {
                
                countDownQuote -= (1) * Time.fixedDeltaTime;
                QuoteCounter();
            }
        }
        private void QuoteCounter() // Starts the code below for Quote Counter.
        {                    
            if (countDownQuote <= 0) // If the count down quote float is less than or equals 0 than it will reset the float back to the original and will set the time done back to true.
            {
                countDownQuote = countDownHold;
                timeDone = true;
            }
            
        }

        private void FirstCheck() // Starts the first Check method.
        {
            if (inTang.playerIsClose == true) // Checks from the InTangable script if the player is close is equal to true. If so it will start the ButtonT method and set timeStart to false.
            {
                ButtonT();
                timeStart = false;               
            }
            else if (inTang2.playerIsClose == true) // Checks from the InTangable script if the player is close is equal to true. If so it will start the ButtonT method and set timeStart to false.
            {
                ButtonT();
                timeStart = false;                
            }
            else if (enemies.closeToMe == true) // Checks if the Enemy Kill Color close to me is set to true. If so it will Start the ButtonE Method and set the timeStart to false.
            {
                ButtonE();
                timeStart = false;                
            }
            
            reCheckAgain = false; // It will set the reCheckAgain to false as well in this method.
           
        }

        private void SecondCheck() // Starts the Second Check Method and the code below.
        {
            if (inTang.playerIsClose == false) // Checks from the InTangable script if the player is close is equal to false. If so it will set the Time Start to true instead.
            {
                timeStart = true;
                
            }
            else if (enemies.closeToMe == false) // Checks the Enemy Kill Color close to me if its set to false than to set the timeStart back to true.
            {
                timeStart = true;
                
            }
            else if (inTang.timerSS == false) // Checks from the InTangable script if the timerSS is equal to false. If so it will set the Time Start to true instead.
            {
                timeStart = true;
                
            }
            else if (inTang.timeWolf == false) // Checks from the InTangable script if the timeWolf is equal to false. If so it will set the Time Start to true instead.
            {
                timeStart = true;
                
            }
            else if (inTang2.playerIsClose == false) // Checks from the InTangable script if the player is close is equal to false. If so it will set the Time Start to true instead.
            {
                timeStart = true;
                
            }
            reCheck = true; // This Method will also set reCheck to true.
        }

        private void AlwaysCheck() // Starts the Always Check Method and the code below.
        {
             if (inTang.timeWolf == true){ // Checks from the InTangable script if the timeWolf is equal to true. If it will start the CountDownTime Method and set the timeStart to false and popUI to true.
                CountDownTime();
                timeStart = false;
                popUI = true;
             }
             else if (inTang.timerSS == true){ // Checks from the InTangable script if the timeSS is equal to true. If it will start the CountDownTime Method and set the timeStart to false and popUI to true.
                CountDownTime();
                timeStart = false;
                popUI = true;
             }           
              reCheck = false; // Method sets reCheck to false.
              reCheckAgain = true; // Method sets reCheckAgain to true.
        }

        private void RoomCheck() // Starts the method for Room Check and the code below.
        {
            if (doorController.openDoor2 == true) // Checks in Door control script if room 2 is opened is set to true.
            {
                if (activate2 == true) // If activate 2 is also set to true it will start the Room2NowOpen method and set timeStart to false.
                {
                    Room2NowOpen();
                    timeStart = false;
                }
                reCheck = false; // Sets the reCheck to false.
                reCheckAgain = true; // Sets the RecheckAgain to true.
            }
        }
        private void ButtonE() // Button E Method prints out a string for pressing E for enemies.
        {
            helpFulHints.text = "Press 'E' To Turn Enemies Blue for 15 Seconds".ToString();
        }
        private void ButtonT() // ButtonT Method prints out a E to press to turn Pillers Visable string.
        {
            helpFulHints.text = "Press 'E' To Turn The Pillers Visible".ToString();
        }
        private void CountDownTime() // CountDownTime displays the time limit and the inTangable float timer count down in a F0 format in the popUI section of the UI.
        {
            timeOrWave.text = "Time Limit: " + inTang.timer.ToString("F0");
        }
        private void CountDownWave() // Displays current waves for the popUI however it has not been setup yet to be used.
        {
            helpFulHints.text = "Wave Round: ".ToString();
        }
        private void Room2NowOpen() // Display Room 2 is now opened however i could not have the string to print correctly so will not display currently.
        {
            helpFulHints.text = "Room 2 is Opened".ToString();
        }

        private void SecondsTimer() // Seconds Timer Method was used for the Room 2 now opened by using a very quick text to pop up in the UI. Currently not in use.
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

        public void Tutorial1Screen1() // Starts the Tutorial 1 UI Screen. Displays the Text and changes the canvas group of all 4 to only display the Tutorial 1 UI screen.
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
        public void Tutorial1Screen2() // Starts the Tutorial 2 UI Screen. Displays the Text and changes the canvas group of all 4 to only display the Tutorial 2 UI screen.
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
        public void Tutorial1Screen3() // Starts the Tutorial 3 UI Screen. Displays the Text and changes the canvas group of all 4 to only display the Tutorial 3 UI screen.
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
        public void Tutorial1Screen4() // Starts the Tutorial 4 UI Screen. Displays the Text and changes the canvas group of all 4 to only display the Tutorial 4 UI screen.
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

        public void EndOfTutorial() // Button to call this method to turn off all canvas groups for the tutoral so the game can start.
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

            Time.timeScale = 1; // UnFeezes the time scale of the game back to 1.
        }

        private void Room2Tutorial() // Displays the Room Tutorial for when the player collides with the game object as told above.
        {           
            room2Tutorial.GetComponent<CanvasGroup>().alpha = 1;
            room2Tutorial.GetComponent<CanvasGroup>().blocksRaycasts = true;
            room2Tutorial.GetComponent<CanvasGroup>().interactable = true;
            textroom2Tutorial.text = "You made it to room 2! :D. \n" + "In this room you will have to use the 2 purple buttons to activate the bridge. Once you have done so you have 35 seconds to get to the other block. Collect all coins to open the next room!".ToString();
            
        }

        public void Room2TutorialOver() // When the player presses continue it sets the tutorial to be inactive.
        {           
            room2Tutorial.SetActive(false);
            
            destroyGO = true;
        }


    }
}
