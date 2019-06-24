using SolidWorks.Interop.sldworks;
using System;

namespace sw_part_auto_test
{
    class Program
    {
        static void Main(string[] args)
        {

            var app = CreateSWInstance.Create();

            Out.Ln("Attempting to open assembly...");

            SWOpenPart.Open(app,
                (DocumentSpecification)app.GetOpenDocSpec(
                    User.GetConsoleInput("Enter File Name:")
                    )
                );
        }
    }
}
