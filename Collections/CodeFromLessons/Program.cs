using System.Collections;

var sortedList = new List<int> { 1,3,4,5,6,11,12,14,16,18 };

Console.WriteLine(sortedList.FindIndexInSorted<int>(16));
Console.WriteLine(sortedList.FindIndexInSorted<int>(1));
Console.WriteLine(sortedList.FindIndexInSorted<int>(18));
Console.WriteLine(sortedList.FindIndexInSorted<int>(11));
Console.ReadKey();

var text = "hello there";
foreach (char c in text)
{
    Console.WriteLine(c);
}
Console.ReadKey();

var customCollection = new CustomCollection(new string[] { "aaa", "bbb", "ccc" });
customCollection = new CustomCollection { "one", "two", "three" };

//var first = customCollection[0];
//customCollection[1] = "abc";
foreach (var word in customCollection)
{
    Console.WriteLine(word);
}
Console.ReadKey();

public static class ListExtensions
{
    public static int? FindIndexInSorted<T>(this IList<T> list, T itemToFind) where T : IComparable<T>
    {
        int leftBound = 0;
        int rightBound = list.Count - 1;
        while (leftBound <= rightBound)
        {
            int middleIndex = (leftBound + rightBound)/2;
            if (itemToFind.Equals(list[middleIndex]))
            {
                return middleIndex;
            }
            else if(itemToFind.CompareTo(list[middleIndex]) < 0)
            {
                rightBound = middleIndex-1;
            }else if(itemToFind.CompareTo(list[middleIndex]) > 0)
            {
                leftBound = middleIndex+1;
            }
        }

        return null;
    }
}

public class CustomCollection : IEnumerable<string>
{
    public string[] Words { get; }
    private int _currentIndex = 0;

    public CustomCollection()
    {
        Words = new string[10]; 
    }

    public void Add(string word)
    {
        Words[_currentIndex] = word;
        ++_currentIndex;
    }

    public CustomCollection(string[] words)
    {
        Words = words;
    }

    public string this[int index]
    {
        get => Words[index];
        set => Words[index] = value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return  GetEnumerator();
    }

    public IEnumerator<string> GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }
}

public class WordsEnumerator : IEnumerator<string>
{
    object IEnumerator.Current
    {
        get
        {
            try
            {
                return _words[_currentPosition];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"{nameof(CustomCollection)}'s end reached.",ex);
            }
        }
    }

    public string Current
    {
        get
        {
            try
            {
                return _words[_currentPosition];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"{nameof(CustomCollection)}'s end reached.", ex);
            }
        }
    }

    private int _currentPosition = -1;
    private readonly string[] _words;

    public WordsEnumerator(string[] words)
    {
        _words = words;
    }

    public bool MoveNext()
    {
        _currentPosition++;
        return _currentPosition < _words.Length;
    }

    public void Reset()
    {
        _currentPosition = -1;
    }

    public void Dispose()
    {
        
    }
}
