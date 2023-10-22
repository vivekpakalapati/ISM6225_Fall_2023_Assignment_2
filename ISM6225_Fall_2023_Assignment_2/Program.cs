/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                List<int> missingrange = new List<int>(); //to track range
                List<IList<int>> rangelist = new List<IList<int>>(); 

                // To jandle the lower edge case
                if (lower < nums[0]) 
                {
                    missingrange.Add(lower); //lower limit of range
                    missingrange.Add(nums[0] - 1); //To finds the upper limit of range by removing 1 from the value in positio n.
                    rangelist.Add(missingrange);
                    lower = nums[0] + 1;
                }

                //To find the missing ranges
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] - nums[i - 1] > 1)
                    { // To Check if the numbers are nonconsecutive
                        missingrange = new List<int>(); 
                        missingrange.Add(nums[i - 1] + 1);
                        missingrange.Add(nums[i] - 1);
                        rangelist.Add(missingrange);
                    }
                }

                // To Handle the upper edge
                if (upper > nums[nums.Length - 1]) 
                {                                  
                    missingrange = new List<int>(); 
                    missingrange.Add(nums[nums.Length - 1] + 1); 
                    missingrange.Add(upper);
                    rangelist.Add(missingrange);
                }
                return rangelist;  
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                Dictionary<char, char> goodbracketcombos = new Dictionary<char, char> 
                {
                    {'(', ')' },
                    {'[', ']' },
                    {'{', '}' }
                };

                List<char> bracketopen = new List<char>();

                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i]; 

                    if (goodbracketcombos.ContainsKey(c))  
                    {
                        bracketopen.Add(c); 
                    }
                    else if (goodbracketcombos.ContainsValue(c)) 
                    {
                        if (bracketopen.Count == 0 || goodbracketcombos[bracketopen[bracketopen.Count - 1]] != c)

                        {
                            return false;
                        }
                        bracketopen.RemoveAt(bracketopen.Count - 1); 
                    }
                }
                return bracketopen.Count == 0; //Tocheck if all open brackets areclosed.

                //return  s.Length=0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Write your code here, and you can modify the return value according to the requirements
                if (prices == null || prices.Length <= 1) //Tocheck if the inputs are valid
                {
                    return 0;
                }

                int maxprofit = 0;
                int lowprice = prices[0];

                for (int i = 1; i < prices.Length; i++) //start the loop w/ i = 1.
                {
                    if (prices[i] < lowprice) 
                    {
                        lowprice = prices[i];
                    }
                    else
                    {
                        int profittracker = prices[i] - lowprice; //TO  monitor the profit
                        if (profittracker > maxprofit) //to track the maximum profit
                        {
                            maxprofit = profittracker;
                        }
                    }
                }

                return maxprofit;

                //return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                int leftpointer = 0; //starts from first int
                int rightpointer = s.Length - 1;  //will start at the last int
                HashSet<string> strobopairs = new HashSet<string>
                {
                    "00", "11", "88", "69", "96"  //strobogrammatic numbers to check
                };
                while (leftpointer <= rightpointer) 
                {
                    char leftchar = s[leftpointer];  // compareing the chars
                    char rightchar = s[rightpointer];

                    if (!strobopairs.Contains($"{leftchar}{rightchar}")) //checking the list strobopairs
                    {
                        return false; //if the pair is not indexer thr hashset.
                    }
                    leftpointer++; 
                    rightpointer--;
                }
                return true;

                //return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                Dictionary<int, int> countMap = new Dictionary<int, int>();
                int goodPairs = 0;

                foreach (int num in nums)
                {
                    if (countMap.ContainsKey(num))
                    {
                        // If the number has been encountered before, add the count of that number to the total count of good pairs.
                        goodPairs += countMap[num];
                        // Raise the count for this number 
                        countMap[num]++;
                    }
                    else
                    {
                        // If it's the first then add to the dictionary.
                        countMap[num] = 1;
                    }
                }

                return goodPairs;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                long firstMax = long.MinValue; //The lowest possible value
                long secondMax = long.MinValue;
                long thirdMax = long.MinValue;

                foreach (int num in nums)
                {
                    if (num == firstMax || num == secondMax || num == thirdMax)
                        continue; // to skip the duplicates

                    if (num > firstMax)
                    {
                        thirdMax = secondMax;
                        secondMax = firstMax;
                        firstMax = num;
                    }
                    else if (num > secondMax)
                    {
                        thirdMax = secondMax;
                        secondMax = num;
                    }
                    else if (num > thirdMax)
                    {
                        thirdMax = num;
                    }
                }

                // return the maximum number if there is no third number.
                return thirdMax == long.MinValue ? (int)firstMax : (int)thirdMax;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                List<string> output = new List<string>();

                for (int i = 0; i < currentState.Length - 1; i++) // This will keep it in bounds
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        char[] nextState = currentState.ToCharArray(); // making this an array.
                        nextState[i] = '-'; 
                        nextState[i + 1] = '-';
                        output.Add(new string(nextState)); //change the results back to string and then add it to the  output.
                    }
                }
                return output;

                //retur new List<string>() { };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            // Write your code here and you can modify the return value according to the requirements
            List<char> newstring = new List<char>();

            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i < s.Length; i++) //if the char is not a vowel. 
            {
                if (!vowels.Contains(s[i]))
                {
                    newstring.Add(s[i]);
                }
            }
            return new string(newstring.ToArray());

            //return "";
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); //opening square bracket

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Adding a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); 

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Createing an array
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Encloseing each string with double quotes
            }

            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
