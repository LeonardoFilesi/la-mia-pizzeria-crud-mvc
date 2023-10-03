namespace la_mia_pizzeria_crud_mvc.CustomLoggers
{
    public class CustomFileLogger
    {
        public void WriteLog(string message)
        {
            File.WriteAllText("C:\\Utenti\\leona\\source\\repos\\la_mia_pizzeria_mvc\\la_mia_pizzeria_mvc\\my-file-logger.txt" , $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}LOG: {message}\n");
        }
    }
}
