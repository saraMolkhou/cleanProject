namespace ClassLibrary1
{
    public static class ReadData
    {
        /// <summary>
        /// פונקציה המקבלת קלט מהמשתמש ומחזמספרירה
        /// </summary>
        /// <param name = "msg" > הודעה למשתמש מה עליו להקליד</param>
        /// <returns>מחזירה את הערך שהמשתמש הקליד כמספר ולא כמחרוזת<returns>
        public static int Readint(string msg = "plaese type a number")//אם לא שולחים זה מה שיכנס לmsg
        {
            Console.WriteLine(msg);
            string msgfromuser = Console.ReadLine();
            int result;
            while (!int.TryParse(msgfromuser, out result))
                Console.WriteLine("Error");
            Console.WriteLine(msg);
            return result;
        }


        /// <summary>
        ///פונקציה שמקבלת קלט מהמשתמש וממירה אותו לתאריך
        /// </summary>
        /// <param name = "msg" ></ param >
        /// < returns ></ returns >
        public static DateTime ReadDate(string msg = "plaese type a number")//אם לא שולחים זה מה שיכנס לmsg
        {
            Console.WriteLine(msg);
            string msgfromuser = Console.ReadLine();
            DateTime result;
            bool isOk = DateTime.TryParse(msgfromuser, out result);
            while (!isOk)
            {
                Console.WriteLine("Error");
                Console.WriteLine(msg);
                isOk = DateTime.TryParse(msgfromuser, out result);

            }
            return result;
        }
        public static object ReadEnum(Type enumType, string msg = "enter a enum")
        {
            Console.WriteLine(msg);
            object enumval;
            bool res = Enum.TryParse(enumType, Console.ReadLine(), ignoreCase: true, out enumval);
            while (!res)
            {
                Console.WriteLine("the value is invalid enter a new one");
                res = Enum.TryParse(enumType, Console.ReadLine(), ignoreCase: true, out enumval);
            }
            return enumval;
        }

        public static void ReadColor()
        {
            object colorResult = ReadEnum(typeof(ConsoleColor), "enter color");
            Console.ForegroundColor = (ConsoleColor)colorResult;
        }
    }

}

