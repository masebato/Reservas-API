

namespace Reservas_DOMAIN.Exception
{
    public class ReservasException : System.Exception
    {
        public int Code;
        public ReservasException() : base() { }
        public ReservasException(string message) : base(message) { }

        public ReservasException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
