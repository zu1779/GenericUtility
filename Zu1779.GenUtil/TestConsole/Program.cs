namespace TestConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    using Zu1779.GenUtil.Extension.BaseTypeExtension;
    using Zu1779.GenUtil.Extension.CaseExtension;
    using Zu1779.GenUtil.Extension.MiscExtension;

    public class Program
    {
        public static void Main()
        {
            new Program().Run();
            
            Console.WriteLine("\r\nPress any key!");
            Console.ReadKey();
        }

        public void Run()
        {
            Action[] actions = new Action[] { BaseTypeExtension, CaseExtension };
            foreach (var action in actions)
            {
                string name = action.Method.Name;
                '='.Repeat(name.Length).Dump();
                name.Dump();
                '-'.Repeat(name.Length).Dump();
                action();
                '='.Repeat(name.Length).Dump();
                "\r\n".Dump();
            }
        }
        private void BaseTypeExtension()
        {
            // char extension
            char lowerCharacter = 'c';
            char upperCharacter = 'D';
            char toUpperCharacter = lowerCharacter.ToUpper();
            char toLowerCharacter = upperCharacter.ToLower();
            Console.WriteLine(toUpperCharacter);
            Console.WriteLine(toLowerCharacter);
        }
        private void CaseExtension()
        {
            IEnumerable<string> fromSC = "casual library user".FromSpaceCase();
            fromSC.DumpEnumerable("fromSC");
            JsonConvert.SerializeObject(fromSC).Dump();

            IEnumerable<string> fromUC = "casual_library_user".FromUnderscoreCase();
            fromUC.DumpEnumerable("fromUC");
            JsonConvert.SerializeObject(fromUC).Dump();

            IEnumerable<string> fromCC = "casualLibraryUser".FromCamelCase();
            fromCC.DumpEnumerable("fromCC");
            JsonConvert.SerializeObject(fromCC).Dump();

            IEnumerable<string> fromPC = "CasualLibraryUser".FromPascalCase();
            fromPC.DumpEnumerable("fromPC");
            JsonConvert.SerializeObject(fromPC).Dump();

            IEnumerable<string> words = new string[] { "casual", "library", "user" };
            string toSpaceCase = words.ToSpaceCase();
            toSpaceCase.Dump(nameof(toSpaceCase));
            string toUnderscoreCase = words.ToUnderscoreCase();
            toUnderscoreCase.Dump(nameof(toUnderscoreCase));
            string toCamelCase = words.ToCamelCase();
            toCamelCase.Dump(nameof(toCamelCase));
            string toPascalCase = words.ToPascalCase();
            toPascalCase.Dump(nameof(toPascalCase));
        }
    }

    public interface ITask
    {
        int Done { get; set; }
        int Total { get; set; }
        double Percentage { get; set; }
        void Do();
        void Complete();
    }
    public class Task : ITask
    {
        public int Done { get; set; }
        public int Total { get; set; }
        public double Percentage { get; set; }

        public void Do() { "Do!!!".Dump(); }
        public void Complete() { "Done!!!".Dump(); }
    }
}
