//THOMAS LE VAVASSEUR DIT DURELL - SOLIRIUS CONSULTING CODING TEST - LIGHT CONTROLLER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace LightController
{
    class LightController
    {
        static void Main(string[] args)
        {
            //initialise variables
            bool intCheck = false;
            bool breakLoop = false;
            string userSets = "20";
            string userMenuEntry;
            Random r = new Random();

            //Allow user to define number of lights within the set
            Console.WriteLine("Please enter the number of lights in the set, Default = 20");
            //read in user response and store in a string
            userSets = Console.ReadLine();

            //error checking user entry
            intCheck = userSets.All(char.IsDigit);
            //should also look into error checking for a maximum value above 2.147b...
            if (!intCheck || (userSets == "") || userSets == "0")
            {
                userSets = "20";
                Console.WriteLine("Invalid input, size defaulted to 20.");
            }
            //initialise array of Lights and initialise all member variables
            Light[] myLights = new Light[Int32.Parse(userSets)];
            for (int i = 0; i < myLights.Length; i++)
            {
                myLights[i].illuminated = false;
                int randColour = r.Next(1, 7);
                //apply random colours for the set by default
                switch (randColour)
                {
                    case 1:
                        myLights[i].setColour("Red");
                        break;
                    case 2:
                        myLights[i].setColour("Blue");
                        break;
                    case 3:
                        myLights[i].setColour("Green");
                        break;
                    case 4:
                        myLights[i].setColour("Yellow");
                        break;
                    case 5:
                        myLights[i].setColour("White");
                        break;
                    case 6:
                        myLights[i].setColour("Purple");
                        break;
                    case 7:
                        myLights[i].setColour("Orange");
                        break;
                    default:
                        myLights[i].setColour("Red");
                        break;
                }
            }
            Console.WriteLine("Set initialised, populated with random coloured lights, all lights are currently off");
            while (breakLoop == false)
            {
                String localTime = DateTime.Now.ToString("h:mm:ss");
                //error checking, this could be expanded upon to become more elegant, e.g tailored error messages to the problem. 
                //returns true if the string is a number
                
                //display UI options to user
                Console.WriteLine("What would you like to do? Please select using the numbers.");
                Console.WriteLine("1) Launch the loop");
                Console.WriteLine("2) Modify the colour of the lights");
                //read in user input
                userMenuEntry = Console.ReadLine();
                //error checking - this could be made more elegant by checking a heirarchy, i.e is it a digit -> is it in range -> etc
                intCheck = userMenuEntry.All(char.IsNumber);
                if (intCheck)
                {
                    switch (Int32.Parse(userMenuEntry))
                    {
                        case 1: //initiate loop
                            {
                                int j = 0;
                                //loop through all array entries
                                Console.WriteLine("Press ESC to stop");
                                while (j < myLights.Length && !(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
                                {
                                    //initialise variables
                                    String lightState;
                                    //turn the light on
                                    myLights[j].changeIllumination();
                                    //parsing a boolean value for lights to a string
                                    if (myLights[j].illuminated == true)
                                    {
                                        lightState = "Light On";
                                    }
                                    else
                                    {
                                        lightState = "Light Off";
                                    }
                                    //print out the current state of the light
                                    Console.WriteLine(localTime + " " + (j + 1) + " " + myLights[j].colour + " " + lightState);
                                    //update the time in our loop
                                    localTime = DateTime.Now.ToString("h:mm:ss");
                                    //wait a second
                                    while (localTime == DateTime.Now.ToString("h:mm:ss"))
                                    {
                                    }
                                    myLights[j].changeIllumination(); //turning the light back off
                                    if (myLights[j].illuminated == true)
                                    {
                                        lightState = "Light On";
                                    }
                                    else
                                    {
                                        lightState = "Light Off";
                                    }
                                    //print out the current state of the light
                                    Console.WriteLine(localTime + " " + (j + 1) + " " + myLights[j].colour + " " + lightState);
                                    //reset if the max is reached
                                    j++;
                                    if (j == myLights.Length)
                                    {
                                        j = 0;
                                    }
                                }
                                break;
                            }
                        case 2: //change colour
                            {
                                //display UI
                                Console.WriteLine("What light would you like to change? 1 - " + userSets);
                                //read in user input
                                string userLightSelection = Console.ReadLine();
                                //error checking
                                intCheck = userLightSelection.All(char.IsDigit);
                                int userLight = (Int32.Parse(userLightSelection) - 1);
                                if (!intCheck || (userLightSelection == "") || !(userLight >= 0 && userLight <= myLights.Length))
                                {
                                    Console.WriteLine("Error: Light doesn't exist");
                                }
                                else
                                {
                                    //parse string into accurate index for array

                                    //check the index is in range

                                    //display UI
                                    Console.WriteLine("Please select the colour you would like the light to be");
                                    Console.WriteLine("1: Red");
                                    Console.WriteLine("2: Blue");
                                    Console.WriteLine("3: Green");
                                    Console.WriteLine("4: Yellow");
                                    Console.WriteLine("5: White");
                                    Console.WriteLine("6: Purple");
                                    Console.WriteLine("7: Orange");
                                    //parse into a switch for the menu selection
                                    int userColour = Int32.Parse(Console.ReadLine());
                                    //initate loop for selecting colour
                                    bool colourChosen = false;
                                    while (colourChosen == false)
                                        switch (userColour)
                                        {
                                            //change colour depending on user input
                                            case 1:
                                                myLights[userLight].setColour("Red");
                                                colourChosen = true;
                                                Console.WriteLine("Colour successfully changed");
                                                break;
                                            case 2:
                                                myLights[userLight].setColour("Blue");
                                                colourChosen = true;
                                                Console.WriteLine("Colour successfully changed");
                                                break;
                                            case 3:
                                                myLights[userLight].setColour("Green");
                                                colourChosen = true;
                                                Console.WriteLine("Colour successfully changed");
                                                break;
                                            case 4:
                                                myLights[userLight].setColour("Yellow");
                                                colourChosen = true;
                                                Console.WriteLine("Colour successfully changed");
                                                break;
                                            case 5:
                                                myLights[userLight].setColour("White");
                                                colourChosen = true;
                                                Console.WriteLine("Colour successfully changed");
                                                break;
                                            case 6:
                                                myLights[userLight].setColour("Purple");
                                                colourChosen = true;
                                                Console.WriteLine("Colour successfully changed");
                                                break;
                                            case 7:
                                                myLights[userLight].setColour("Orange");
                                                colourChosen = true;
                                                Console.WriteLine("Colour successfully changed");
                                                break;
                                            default:
                                                Console.WriteLine("Please pick a colour from the appropriate numbers (1-7)");
                                                break;
                                        }

                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please input a valid number: 1 or 2)");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Please input a valid number: 1 or 2)");
                }
            }
        }
        public struct Light
        {
            public Boolean illuminated;
            public String colour;

            //constructor if needed
            public Light(Boolean startState, String startColour)
            {
                illuminated = startState;
                colour = startColour;
            }
            //turns light on / off
            public void changeIllumination()
            {
                if (illuminated == true)
                {
                    illuminated = false;
                }
                else if (illuminated == false)
                {
                    illuminated = true;
                }
                return;
            }
            //sets the colour of the light
            public void setColour(string userColour)
            {
                colour = userColour;
                return;
            }

        }
    }
}
