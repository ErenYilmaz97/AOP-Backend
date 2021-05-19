using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {

        //SADECE VERİ
        public SuccessDataResult(T data):base(data,true)
        {

        }




        //SADECE MESAJ
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }




        //VERİ-MESAJ
        public SuccessDataResult(T data, string message):base(data,true,message)
        {

        }



        //BOŞ
        public SuccessDataResult():base(default,true)
        {

        }



       
    }
}
