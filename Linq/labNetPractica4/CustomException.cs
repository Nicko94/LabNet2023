using System;

namespace LabNetPractica4.Logic
{
    public class CustomException : Exception
    {
        public CustomException(string Message) : base(Message)
        {
        }
    }
}