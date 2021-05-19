using Newtonsoft.Json;

namespace Core.Extensions
{
    public class ResponseErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }


        //NESNEYİ JSONA ÇEVİR
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}