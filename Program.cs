// Angelia Burgos Zamora
// angeliaburgos55@gmail.com



using System;
using System.Drawing;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        ///


       static List<string> theList = new List<string>();

       static Queue<string> icaQueue = new Queue<string>();

        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }



        // upg.1 examine list

        static void ExamineList()
        {
            // while is used to loop program 

            while (true)
            {
                Console.WriteLine("Enter + infront of input to add element to list, use - infront of input to remove element from list, or enter exit to return to main menu");

                // reads user input and stores in variable input
                string input = Console.ReadLine();
                input.Reverse();
                // checks if user has input 'exit' both in upper and lowercase- if so the loop ends and returns to the main menu
                if (input.ToLower() == "exit")
                    break;

                // takes the first sign of the string from user input and stores in variable nav. in this case + or - 
                char nav = input[0];

                // extract rest of string from user input and stores in variable value, this is the input that is added or removed from the list
                string value = input.Substring(1);


                // compares the stored input in nav with different cases + or -
                switch (nav)
                {
                    // if input + the AddToList function is executed
                    case '+':
                        AddToList(value);
                        break;

                    // if input - the RemoveFromList function is executed
                    case '-':
                        RemoveFromList(value);
                        break;
                    default:
                        Console.WriteLine("Use + to add, or - to remove element from list");
                        break;

                }
            }
        }


        // adds element to list based on user's input
        static void AddToList(string value)
        {
            theList.Add(value);
            Console.WriteLine(value + " " + "has been added to the list");
            ListInformation();
        }

        // removes element from list based on user's input
        static void RemoveFromList(string value)
        {
            if (theList.Remove(value))
            Console.WriteLine(value + " " + "has been removed from the list");
            ListInformation();
        }

        // lists the count and capacity of the list
        static void ListInformation()
        {
            Console.WriteLine("List count: " + theList.Count + ", " + "List capacity: " + theList.Capacity);
        }


        // Frågor:
        // 1. When a element exceeds the capacity of the list, in this case the list capacity is 4 as default. 
        // 2. When the list capacity is exceeded, for example when a 5 element is added to the list, the list will re-size itself to the double capacity.
        // 3. This is how the list is designed (4) I also think that re-sizing a list when ever an element is added is unnecessary usage of computer power.
        // 4. No the list capacity does not change back if elements are removed from the list
        // 5. A pre-defined array is useful when you know how many elements it will contain.

        // upg.1 examine list - slut



        // upg.2 examine queue

        static void ExamineQueue()
        {
            // while is used to loop program 
            while (true)
                {
                    Console.WriteLine("Welcome to the ICA-Queue");
                    Console.WriteLine("Enter + infront of input to add person to the queue, use - infront of input to remove person from the queue, or enter exit to return to main menu");

                // reads user input and stores in variable input
                string input = Console.ReadLine();

                // checks if user has input 'exit' both in upper and lowercase- if so the loop ends and returns to the main menu
                if (input.ToLower() == "exit")
                        break;

                // extracts the first charachter of the user input, which represent the user's action (+ = add to queue) or (- = remove from queue) 
                char nav = input[0];

                // extract rest of string from user input and stores in variable value, this is the person that is added or removed from the queue
                string value = input.Substring(1);

                //inside the switch statement different actions are perfomed (adding or removing person from queue)
                switch (nav)
                    {

                    // the person (name) that stands for value is added to the queue
                    // the queue.Count displays the current number of people that are in the queue
                    case '+':
                            icaQueue.Enqueue(value);
                            Console.WriteLine(value + " " + "has been added to the queue");
                            Console.WriteLine("there are " + icaQueue.Count + " people in the queue");
                            break;

                    // the dequeue method removes a person from the queue
                        case '-':
                            Console.WriteLine(icaQueue.Dequeue());
                            Console.WriteLine(value + " " + "has left the queue");
                            Console.WriteLine("there are " + icaQueue.Count + " people in the queue");
                            break;
                    }

                }
            }

        // upg.2 examine queue - slut


        // upg.3 examine stack

        static void ExamineStack()
        {
            while (true)
            {
                Console.WriteLine("Enter a string to reverse it, enter pop to reverse the string, or enter exit to return to the main menu");

                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                string reversedText = ReverseText(input);

                Console.WriteLine("Reversed string");
                Console.WriteLine(reversedText);

            }

        }

        // takes the string input as a parameter and returns the reversed version of the string
        static string ReverseText (string input)
        {
            // holds charachters of the input string  
            Stack<char> charStack = new Stack<char>();

            // iterates over each charachter in the input string and "pushes" each charachter onto the stack
            foreach (char c in input)
            {
                charStack.Push(c);
            }

            // creates an empty string that holds the reversed version of the intial string input
            string reversedText = "";
            while (charStack.Count > 0)
            {
                reversedText += charStack.Pop();
            }

            return reversedText;
        }

        // Frågor:
        // 1. A stack is not useful for a queue as the first person in the queue will get help lastly.
        // In this part I choose not to include the swith statement as it was not clear to me why this is needed
        // if a user chooses to pop a string then nothing will be displayed if user has not first pushed a string to the stack and therefore nothing will be returned (poped) as the stack is empty
        // do not understand why a switch statement is needed here.
        // upg.3 examine stack slut

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}




// Teori & Fakta frågor:
//
// 1. The stack is used for quick local variables and functions which automatically manages memory allocation and deallocation.
//    The heap is a bigger memory space for allocation of objects with longer life-lenght that require manual memory allocation and deallocation.
// 
// 2. Value types include basic data types like int and float, it stores values directly in memory and are copied through value.
//    Reference types includes classes and arrayes, it stores a reference of the data and are copied through reference.
//
// 3. In the first method the value of x is copied to y, which means that the changes in y does not affect x.
//    In the second method x and y share the same reference to an obejct, therefore the changes to y are also applied to x.
