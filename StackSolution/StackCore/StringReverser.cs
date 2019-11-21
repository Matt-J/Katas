using System;

namespace StackCore
{
    public class StringReverser : IStringReverser
    {
        public string ReverseString(string stringToReverse)
        {
            throw new NotImplementedException();
        }
    }

    public interface IStringReverser
    {
        string ReverseString(string stringToReverse);
    }
}
