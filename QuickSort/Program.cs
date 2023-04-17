using System.Reflection.Emit;

Console.WriteLine("=== Welcome to SortRUs ===\n");

int[] arr = { 10, 23, 2, 446, 8, 45 };
int arrLength = arr.Length;

Console.WriteLine("Press 1 to see a predetermined Array.\nPress 2 to create a custom array!");
reTry:
if (Int32.TryParse(Console.ReadLine(), out int l))
{
    switch (l)
    {
        case 1:
            Console.Clear();
            QuickSorting(arr, 0, arrLength - 1);
            WriteArray(arr, arrLength);
            break;

        case 2:
            Console.Clear();
            int[] customArray = UserArray();
            QuickSorting(customArray, 0, customArray.Length - 1);
            WriteArray(customArray, customArray.Length);
            break;

        default:
            Console.WriteLine("Try again.");
            goto reTry;
    }
}
else
{
    Console.WriteLine("Try again.");
    goto reTry;
}


static int[] UserArray()
{
    Console.WriteLine("How many numbers are you working with?");
    if (Int32.TryParse(Console.ReadLine(), out int arrLength))
    {
        int[] cArray = new int[arrLength];

        Console.WriteLine("Please insert your numbers: ");
        for (int pos = 0; pos < cArray.Length; pos++)
        {
            if (Int32.TryParse(Console.ReadLine(), out int arrNumber))
            {
                cArray[pos] = arrNumber;
            }
            else
            {
                pos--;
            }
        }
        return cArray;
    }
    return new int[0];
}
static void WriteArray(int[] arr, int size)
{
    Console.WriteLine("Array in ascending order: ");
    for (int i = 0; i < size; i++)
    {
        Console.Write(arr[i] + " | ");
    }
}

static int Part(int[] arr, int low, int high)
{
    int pivot = arr[high];
    int i = (low - 1);

    for (int j = low; j <= high - 1; j++)
    {
        if (arr[j] < pivot)
        {
            i++;
            Swap(arr, i, j);
        }
    }
    Swap(arr, i + 1, high);
    return (i + 1);
}
static void QuickSorting(int[] arr, int low, int high)
{
    if (low < high)
    {
        int partitionPos = Part(arr, low, high);

        QuickSorting(arr, low, partitionPos - 1);
        QuickSorting(arr, partitionPos + 1, high);
    }
}
static void Swap(int[] arr, int i, int j)
{
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}


