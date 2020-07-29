using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CarInfo.Core.Exceptions
{
    [Serializable]
    public class CarNotFoundException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CarNotFoundException()
        {
        }

        public CarNotFoundException(string message) : base(message)
        {
        }

        public CarNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CarNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
