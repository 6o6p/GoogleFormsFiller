using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Infrastructure
{
    class PublicLoadParser
    {
        public string ParsePublicLoadFromPage(string page)
        {
            var rawPublicLoad = page.Split("var FB_PUBLIC_LOAD_DATA_ = ")[1];

            var squareBracketCounter = 2;
            var temp = string.Empty;

            for (var i = 0; i < rawPublicLoad.Length; i++) 
            {
                if (rawPublicLoad[i] == '[')
                    squareBracketCounter--;

                if (squareBracketCounter < 0 && rawPublicLoad[i] == '[')
                {
                    temp = rawPublicLoad.Substring(i);
                    break;
                }
            }

            //var publicLoad = new StringBuilder();

            //foreach(var character in rawPublicLoad)
            //{ 

            //}

            return temp;
        }

        //public string Parse
    }
}
