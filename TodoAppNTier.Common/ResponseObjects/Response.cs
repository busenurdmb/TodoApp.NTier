using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppNTier.Common.ResponseObjects
{
   public class Response:IResponse
    {
        //RESPONSETYPEDAN responsetype ı parametre olarak alırım
        //benim properti olan responsetypıma prometre olarak aldığım response typmımı eşitliyom
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }
        //yani ben responsetype oluşturduğum zaman 2 tane ctor la oluşturucam sadece responsetype ı geçebilirim
        //mesaj geçmeden yada herikisinide
        public Response(ResponseType responseType,string message)
        {
            ResponseType = responseType;
            Message = message;
        }
        //ilgili durum başarılı başarısızlık durumu
        public string Message { get; set; }

        public ResponseType ResponseType { get; set; }
    }
    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound
    }
  }
