using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedal.Web.Helpers
{
    public class TrackIdGenerotor
    {
        public static string Generate()
        {
            const string arrr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rnd = new Random();
            var str = "";
            for (var i = 0; i < 5; i++)
            {
                var next = rnd.Next(0, 35);
                str += arrr[next];
            }
            return str;

        }
    }
}