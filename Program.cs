// See https://aka.ms/new-console-template for more information




//adjacentElementsProduct(new int[] { -23, 4, -3, 8, -12 });



int[][] jaggedArray = new int[2][];
jaggedArray[0] = new int[] { 1, 1, 1 };
jaggedArray[1] = new int[] { 1, 1, 0 };

jaggedArray[2] = new int[] { 1, 0, 1 };
//jaggedArray[0] = new int[] { 0, 0, 0 };
//jaggedArray[1] = new int[] { 0, 0, 0 };
//[[0,0,0],[0,0,0]]

FloodFill(jaggedArray, 1, 0, 2);
//almostIncreasingSequence(new int[] { 1, 2, 1, 2 });
//polygon(3);
int solution(string s, string t)
{
    var NewText = s;
    var temp = 0;
    for (int i = 0; i < s.Length; i++)
    {
        int myInt = 0;
        bool isNumerical = int.TryParse(s.Substring(i, 1), out myInt);
        if (isNumerical)
        {
            NewText = s.Remove(i, 1);

            List<string> stringList = new List<string>();
            var test = string.Compare(t, NewText);


            if (test == 1)
            {
                temp++;
            }
        }
    }
    for (int i = 0; i < t.Length; i++)
    {
        int myInt = 0;
        bool isNumerical = int.TryParse(t.Substring(i, 1), out myInt);
        if (isNumerical)
        {
            NewText = t.Remove(i, 1);

            var test = string.Compare(NewText, s);


            if (test == 1)
            {
                temp++;
            }
        }
    }
    return temp;
}

void Fill(int[][] image, int row, int col, int originalColor, int fillColor)
{
    if (row < 0 || row >= image.Length || col < 0 || col >= image[0].Length)
    {
        return;
    }

    if (image[row][col] != originalColor)
    {
        return;
    }

    image[row][col] = fillColor;

    Fill(image, row - 1, col, originalColor, fillColor); // fill left pixel
    Fill(image, row + 1, col, originalColor, fillColor); // fill right pixel
    Fill(image, row, col - 1, originalColor, fillColor); // fill top pixel
    Fill(image, row, col + 1, originalColor, fillColor); // fill bottom pixel
}

int[][] FloodFill(int[][] image, int sr, int sc, int color)
{
    int originalColor = image[sr][sc];

    if (originalColor == color)
    {
        return image;
    }
      Fill(image, sr, sc, originalColor, color);
    return image;
}

int adjacentElementsProduct
(int[] inputArray)
{
    var lastnumber = 0;
    int bigestNumber = -10000;
    foreach (var number in inputArray)
    {
        if(lastnumber!=0)
        if (number * lastnumber > bigestNumber)
        {
            bigestNumber = number * lastnumber;
        }
        lastnumber = number;

    }
    return bigestNumber;
}

int polygon(int n)
{
    int perimeter = 0;

    perimeter += 1;

    // Add the length of the sides of the inner rims (if any)
    for (int i = 1; i < n; i++)
    {
        perimeter += 4 * i;
    }

    return perimeter;
}

bool almostIncreasingSequence(int[] sequence)
{
    int n = sequence.Length;
    // Stores the count of numbers that
    // are needed to be removed
    int count = 0;

    // Store the index of the element
    // that needs to be removed
    int index = -1;

    // Traverse the range [1, N - 1]
    for (int i = 1; i < n; i++)
    {
        //1,2,1,2
        // If arr[i-1] is greater than
        // or equal to arr[i]
        if (sequence[i - 1] >= sequence[i])
        {

            // Increment the count by 1
            count++;

            // Update index
            index = i;
        }
    }

    // If count is greater than one
    if (count > 1)
        return false;

    // If no element is removed
    if (count == 0)
        return true;

    // If only the last or the
    // first element is removed
    if (index == n - 1 || index == 1)
        return true;

    // If a[index] is removed
    if (sequence[index - 1] < sequence[index + 1])
        return true;

    // If a[index - 1] is removed
    if (sequence[index - 2] < sequence[index])
        return true;

    return false;


}




long solution2(int[] a)
{
    List<string> resultList = new List<string>();
    for (int index = 0; index < a.Length; index++)
    {

        for (int indexTwo = 0; indexTwo < a.Length; indexTwo++)
        {
            resultList.Add(a[index].ToString() + a[indexTwo].ToString());

        }
    }
    long sum = 0;
    foreach (var temp in resultList)
    {
        sum = sum + Convert.ToInt64(temp);
    }
    return sum;
}

int matrixElementsSum(int[][] matrix)
{

    var sum = 0;
    for (int row = 0; row < matrix.Length; row++)
    {

        for (int column = 0; column < matrix[row].Length; column++)
        {
            if (matrix[row][column] != 0)
            {
                if (row == 0)
                {
                    sum = sum + matrix[row][column];
                }
                else
                {
                    if (CheckIfUpperContainsGhost(matrix, row, column))
                    {

                        sum = sum + matrix[row][column];

                    }
                }


            }

        }

    }
    return sum;
}
bool CheckIfUpperContainsGhost(int[][] matrix, int row, int column)
{
    if (matrix[row][column] == 0)
    {
        return false;
    }
    if (row == 0)
    {
        return true;
    }
    if (matrix[row - 1][column] == 0)
    {
        return false;
    }
    else
    {
        return CheckIfUpperContainsGhost(matrix, row - 1, column);
    }
}

