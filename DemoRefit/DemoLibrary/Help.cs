using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary
{
   public class Help
    {
        public static Help instance { get; } = new Help();
        public bool checkInit;
    }
}
