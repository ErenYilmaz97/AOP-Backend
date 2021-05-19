using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        //SADECE VERİ
        public ErrorDataResult(T data) : base(data, false)
        {

        }




        //SADECE MESAJ
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }




        //VERİ-MESAJ
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }



        //BOŞ
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
