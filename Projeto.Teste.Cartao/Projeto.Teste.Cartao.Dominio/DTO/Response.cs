using System.Collections.ObjectModel;
using System.Net;

namespace Projeto.Teste.Cartao.Dominio.DTO
{
    public class Response
    {
        private readonly IList<string> _messages = new List<string>();

        public IEnumerable<string> Errors { get; }
        public object Result { get; }
        public HttpStatusCode Status { get; private set; } = HttpStatusCode.OK;

        public Response() => Errors = new ReadOnlyCollection<string>(_messages);

        public Response(object result) : this() => Result = result;

        public Response(HttpStatusCode status, object result)
        {
            Result = result;
            Status = status;
            Errors = new ReadOnlyCollection<string>(_messages);
        }

        public Response(HttpStatusCode status)
        {
            Status = status;
            Errors = new ReadOnlyCollection<string>(_messages);
        }

        public Response AddError(string message)
        {
            _messages.Add(message);
            return this;
        }

        public Response AddError(HttpStatusCode status, string message)
        {
            Status = status;
            _messages.Add(message);
            return this;
        }
    }
}